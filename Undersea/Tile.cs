using System;
using Gtk;
using System.Collections.Generic;
using System.Reflection;

namespace Undersea
{
	public abstract class Tile : RenderObject, GameObject, GridObject
	{	
		protected int m_gridPosX = 0;
		protected int m_gridPosY = 0;
		protected List<Tile> m_connectedTiles = new List<Tile>();
		protected bool m_passable = false;
		protected bool m_wet = false;
		protected float m_currentHealth = 0;
		protected int m_maxHealth = 0;
		protected TileType m_tileType = TileType.Rock;
		
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

		public GridCoord GetGridPosition()
		{
			return new GridCoord(m_gridPosX, m_gridPosY);
		}

		public float GetHealth() {
			return this.m_currentHealth;
		}
		
		public float GetMaxHealth() {
			return this.m_maxHealth;
		}

		public bool Passable {
			get {
				return this.m_passable;
			}
		}

		public bool Wet {
			get {
				return this.m_wet;
			}
		}
		
		public bool CanTakeDamage()
		{
			return (this.m_currentHealth > 0);
		}	 
		
		public virtual void TakeDamage(float damage, DamageType type)
		{
			// Tiles take no damage from anything, by default.
			// Please override!
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

