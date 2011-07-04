using System;
namespace Undersea
{
	public class TileSteamvent : Tile, RenderObject, GameObject, GridObject
	{
		public TileSteamvent ()
		{
			m_passable = false;
			m_currentHealth = 0;
			m_tileType = TileType.Steamvent;
		}
		
		public override void Draw()
		{
			MainWindow.GetRenderer().DrawText(new GridCoord(m_gridPosX + .4f, m_gridPosY + .4f), 8, "Vent", System.Drawing.Color.White);
		}
		
		public override void Process(int milliseconds)
		{
			// Do nothing
		}
	}
}

