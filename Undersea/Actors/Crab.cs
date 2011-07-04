using System;
namespace Undersea
{
	public class Crab : Actor, GameObject, RenderObject, GridObject
	{
		public Crab ()
		{
			m_currentHealth = 100;
			m_height = 0.2f;
			m_radius = 0.3f;
			m_maxHealth = m_currentHealth;
			m_canFloat = false;
		}
		
		public override void Draw()
		{
			// Draw each leg and the head, centred at grid position.
		}
		
		public override void Process(int milliseconds)
		{
			
		}
	}
}

