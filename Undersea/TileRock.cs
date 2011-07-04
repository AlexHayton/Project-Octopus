using System;
namespace Undersea
{
	public class TileRock : Tile, RenderObject, GameObject, GridObject
	{
		public TileRock ()
		{
			m_passable = false;
			m_currentHealth = 200;
			m_tileType = TileType.Rock;
		}
		
		public override void Draw()
		{
			MainWindow.GetRenderer().DrawText(new GridCoord(m_gridPosX + .4f, m_gridPosY + .4f), 8, "Rock", System.Drawing.Color.White);
		}
		
		public override void Process(int milliseconds)
		{
			// Do nothing
		}
		
		public override void TakeDamage(float damage, DamageType type)
		{
			float realDamage = damage;
			
			// Fire does nothing to rocks!
			if (type == DamageType.Fire)
			{
				realDamage *= 0;
			}
			
			m_currentHealth = (float)Math.Max(0, m_currentHealth - realDamage);
		}
	}
}

