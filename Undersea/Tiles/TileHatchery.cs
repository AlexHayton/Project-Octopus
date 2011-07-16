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
		
		public override void Process(int milliseconds)
		{
			// Do nothing
		}
	}
}

