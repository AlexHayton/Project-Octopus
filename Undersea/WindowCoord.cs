using System;
namespace Undersea
{
	public class WindowCoord
	{
		private float m_X;
		private float m_Y;
		
		public float X {
			get {
				return this.m_X;
			}
			set {
				m_X = value;
			}
		}

		public float Y {
			get {
				return this.m_Y;
			}
			set {
				m_Y = value;
			}
		}

		public WindowCoord(float initialX, float initialY)
		{
			m_X = initialX;
			m_Y = initialY;
		}
	}
}

