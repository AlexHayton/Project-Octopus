using System;
namespace Undersea
{
	public class TileSand : Tile, RenderObject, GameObject, GridObject
	{
		public TileSand ()
		{
			m_passable = true;
			m_currentHealth = 0;
			m_tileType = TileType.Sand;
		}
		
		public override void Draw()
		{
			MainWindow.GetRenderer().DrawText(new GridCoord(m_gridPosX + .4f, m_gridPosY + .4f), 8, "Sand");
		}
		
		public override void Process(int milliseconds)
		{
			// Do nothing
		}
	}
}

