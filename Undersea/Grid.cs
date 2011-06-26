using System;
namespace Undersea
{
	public class Grid : GameObject
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
		
		public Grid(int initialX, int initialY)
		{
			m_sizeX = initialX;
			m_sizeY = initialY;
			m_tiles = new Tile[m_sizeX*m_sizeY];
			Random random = new Random(1);
			
			for (int i = 0; i<(m_sizeX*m_sizeY)+1;i++)
			{
				int rand = random.Next();
				Tile.TileType type = Tile.TileType.Rock;
				Tile tile;
				switch(type)
				{
				default:
					tile = new TileRock();
					break;
				}
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