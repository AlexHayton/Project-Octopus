using System;
namespace Undersea
{
	public class TileBedrock : Tile, RenderObject, GameObject, GridObject
	{
		public TileBedrock ()
		{
			m_passable = false;
			m_currentHealth = 0;
			m_tileType = TileType.Bedrock;
		}
		
		public override void Process(int milliseconds)
		{
			// Do nothing
		}
	}
}

