using System;
using System.Collections.Generic;
namespace Undersea
{
	public class KeyHandler
	{
		private Dictionary<string,KeyAction> m_actionlist = new Dictionary<string,KeyAction>();
		
		public KeyHandler ()
		{
		}
		
		public void AddAction(string key, KeyAction action)
		{
			m_actionlist.Add(key, action);
		}
		
		public void KeyDown(string key)
		{
			if (m_actionlist.ContainsKey(key))
				m_actionlist[key].KeyDown();
		}
		
		public void KeyUp(string key)
		{
			if (m_actionlist.ContainsKey(key))
				m_actionlist[key].KeyUp();
		}
		
		public void Process(int milliseconds)
		{
			// Update each action as the key is held.
			foreach (KeyAction action in m_actionlist.Values)
			{
				if (action.Held)
				{
					action.KeyHeld(milliseconds);
				}
			}
		}
	}
}

