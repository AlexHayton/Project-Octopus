using System;
namespace Undersea
{
	public interface GameObject
	{	
		float GetHealth();
		float GetMaxHealth();
		bool CanTakeDamage();
		void TakeDamage(float damage, DamageType type);
		void Process(int milliseconds);
	}
}

