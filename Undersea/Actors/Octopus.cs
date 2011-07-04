using System;
namespace Undersea
{
	public class Octopus : Actor, RenderObject, GameObject, GridObject
	{
		public Octopus ()
		{
			m_radius = 1;
			m_height = 0.5f;
			m_currentHealth = 1000;
			m_canFloat = true;
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

