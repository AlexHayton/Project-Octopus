using System;
namespace Undersea
{
	public class TileHatchery : Tile, RenderObject, GameObject, GridObject
	{
		public TileHatchery ()
		{
			m_passable = false;
			m_currentHealth = 500;
			m_tileType = TileType.Hatchery;
		}
		
		public override void Draw()
		{
			MainWindow.GetRenderer().DrawText(new GridCoord(m_gridPosX + .4f, m_gridPosY + .4f), 8, "Hatch", System.Drawing.Color.White);
		}
		
		public override void Process(int milliseconds)
		{
			// Do nothing
		}
	}
}

