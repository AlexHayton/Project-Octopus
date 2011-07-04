using System;
using System.Collections.Generic;
namespace Undersea
{
	public class Grid : RenderObject
	{
		
		private int m_sizeX = 0;
		private int m_sizeY = 0;
		private Tile[] m_tiles;
		
		public int SizeX {
			get {
				return this.m_sizeX;
			}
		}

		public int SizeY {
			get {
				return this.m_sizeY;
			}
		}
		
		public Grid(string filename)
		{
			this.Load(filename);
		}
		
		public bool IsEdgeTile(GridCoord coord)
		{
			if ((coord.X == 0)
			    ||
			    (coord.Y == 0)
			    ||
			    (coord.X == this.SizeX - 1)
			    ||
			    (coord.Y == this.SizeY - 1))
				return true;
			else
				return false;
		}
		
		public Grid(int initialX, int initialY)
		{
			m_sizeX = initialX;
			m_sizeY = initialY;
			m_tiles = new Tile[m_sizeX*m_sizeY];
			Random random = new Random(1);
			
			GridCoord gridcoord = new GridCoord(0,0);
			
			// Enumerate the tile type array.
			Tile.TileType[] typearray = (Tile.TileType[])Enum.GetValues(Type.GetType("Tile.TileType"));
			List<Tile.TileType> typelist = new List<Tile.TileType>(typearray);
			typelist.Remove(Tile.TileType.Max);
			typelist.Remove(Tile.TileType.OctopusGarden);
			
			for (int i = 0; i<(m_sizeX*m_sizeY)+1;i++)
			{
				gridcoord.X = (float)Math.Floor((float)i / (float)m_sizeY);
				gridcoord.Y = i%m_sizeY;
				Tile.TileType type = Tile.TileType.Rock;
				
				// Edge tiles are always rock.
				if (this.IsEdgeTile(gridcoord))
				{
					type = Tile.TileType.Rock;
				}
				else
				{
					// Pick a random tile for now. Later define some simple rules for tile growth
					int rand = random.Next(typelist.Count);
					type = typelist[rand];
				}
				
				// Actually create the tile.
				Tile tile;
				switch(type)
				{	
					case Tile.TileType.Rock:	
						tile = new TileRock();
						break;
					
					case Tile.TileType.Sand:
					default:
						tile = new TileSand();
						break;
							
				}
				
				// Set the tile in the grid.
				m_tiles[i] = tile;
			}
		}
		
		public void Draw()
		{
			foreach (Tile tile in m_tiles)
			{
				tile.DrawBorder();
				tile.Draw();
			}
		}
		
		public void Process(int milliseconds)
		{
			foreach (Tile tile in m_tiles)
			{
				tile.Process(milliseconds);
			}
		}
		
		public void Load(string filename)
		{
			
		}
	}
}