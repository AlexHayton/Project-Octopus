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
		
		public override void Process(int milliseconds)
		{
			// Do nothing
		}
	}
}

