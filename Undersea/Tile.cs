using System;
using Gtk;
using System.Collections.Generic;
using System.Reflection;

namespace Undersea
{
	public abstract class Tile : GameObject
	{	
		private int m_gridPosX = 0;
		private int m_gridPosY = 0;
		private List<Tile> m_connectedTiles;
		
		public enum TileType
		{
			OctopusGarden,
			Sand,
			Rock,
			Steamvent,
			Seaweed,
			Hatchery,
			Wall,
			Lair,
			Max
		}
		
		public static int GetNumberOfTileTypes()
		{
			return (int)TileType.Max;
		}
		
		public List<Tile> ConnectedTiles {
			get {
				return this.m_connectedTiles;
			}
			set {
				m_connectedTiles = value;
			}
		}

		public int GridPosX {
			get {
				return this.m_gridPosX;
			}
		}

		public int GridPosY {
			get {
				return this.m_gridPosY;
			}
		}

		public abstract void Draw();
		public abstract void Process(int milliseconds);
		
		public void DrawBorder()
		{
			Renderer renderer = MainWindow.GetRenderer();
			
			GridCoord topLeft = new GridCoord(m_gridPosX, m_gridPosY);
			GridCoord bottomLeft = new GridCoord(m_gridPosX, m_gridPosY+1);
			GridCoord bottomRight = new GridCoord(m_gridPosX+1, m_gridPosY+1);
			GridCoord topRight = new GridCoord(m_gridPosX, m_gridPosY+1);
			renderer.DrawLine(topLeft, topRight);
			renderer.DrawLine(topRight, bottomRight);
			renderer.DrawLine(bottomRight, bottomLeft);
			renderer.DrawLine(bottomLeft, topLeft);
		}
	}
}

