using System;
namespace Undersea
{
	public abstract class Actor : RenderObject, GameObject, GridObject
	{	
		protected float m_currentHealth = 100;
		protected float m_maxHealth = 100;
		protected float m_gridPosX = 0;
		protected float m_gridPosY = 0;
		protected float m_targetPosX = 0;
		protected float m_targetPosY = 0;
		protected float m_floatHeight = 0;
		protected float m_radius = 0;
		protected float m_height = 0;
		protected bool m_canFloat = false;
			
		public virtual float GetHealth()
		{
			return m_currentHealth;
		}
		
		public virtual float GetMaxHealth()
		{
			return m_maxHealth;
		}
		
		public virtual bool CanTakeDamage()
		{
			return (m_currentHealth > 0);
		}
		
		public float Height {
			get {
				return this.m_height;
			}
		}

		public float Radius {
			get {
				return this.m_radius;
			}
		}

		public virtual bool IsAlive()
		{
			return (m_currentHealth > 0);
		}
		
		public bool CanFloat {
			get {
				return this.m_canFloat;
			}
		}

		public float FloatHeight {
			get {
				return this.m_floatHeight;
			}
		}

		public virtual GridCoord GetGridPosition()
		{
			return new GridCoord(m_gridPosX, m_gridPosY);
		}
		
		public virtual void TakeDamage(float damage, DamageType type)
		{
			// Default behaviour: handle all damage as 'normal'
			m_currentHealth = Math.Max(0, m_currentHealth - damage);
		}
		
		public abstract void Draw();
		public abstract void Process(int milliseconds);
	}
}

