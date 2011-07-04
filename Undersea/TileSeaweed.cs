using System;
namespace Undersea
{
	public class TileSeaweed : Tile, RenderObject, GameObject, GridObject
	{
		public TileSeaweed ()
		{
			m_passable = true;
			m_currentHealth = 0;
			m_tileType = TileType.Seaweed;
		}
		
		public override void Draw()
		{
			MainWindow.GetRenderer().DrawText(new GridCoord(m_gridPosX + .4f, m_gridPosY + .4f), 8, "Weed");
		}
		
		public override void Process(int milliseconds)
		{
			// Do nothing
		}
		
		public override void TakeDamage(float damage, DamageType type)
		{
			float realDamage = damage;
			
			// Fire does double!
			if (type == DamageType.Fire)
			{
				realDamage *= 2;
			}
			
			m_currentHealth = Math.Max(0, m_currentHealth - realDamage);
		}
	}
}

