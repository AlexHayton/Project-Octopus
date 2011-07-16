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
			m_texture = "images/TileSand.jpg";
		}
		
		public override void Process(int milliseconds)
		{
			// Do nothing
		}
	}
}

