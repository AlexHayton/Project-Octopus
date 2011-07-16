using System;
namespace Undersea
{
	public class KeyAction
	{
		public delegate void KeyDownMethod();
		public delegate void KeyUpMethod();
		public delegate void KeyHeldMethod(int ticks);
		
		private KeyDownMethod m_keydown;
		private KeyUpMethod m_keyup;
		private KeyHeldMethod m_keyheld;
		
		private int m_heldMilliseconds = 0;
		private bool m_held = false;
		
		public KeyAction (KeyDownMethod keydown, KeyUpMethod keyup, KeyHeldMethod keyheld)
		{
			m_keydown = keydown;
			m_keyup = keyup;
			m_keyheld = keyheld;
		}
		
		public void KeyDown()
		{
			if (m_keydown != null)
				m_keydown();
			m_held = true;
			m_heldMilliseconds = 0;
		}
		
		public void KeyUp()
		{
			if (m_keyup != null)
				m_keyup();
			m_held = false;
		}
		
		public void KeyHeld(int milliseconds)
		{
			m_heldMilliseconds += milliseconds;
			if (m_keyheld != null)
				m_keyheld(m_heldMilliseconds);
		}
	

		public bool Held {
			get {
				return this.m_held;
			}
		}
}
}

