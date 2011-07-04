using System;
namespace Undersea
{
	public class Camera : GridObject
	{
		private float m_fov = 90;
		private float m_gridPosX = 0;
		private float m_gridPosY = 0;
		private static float s_scrollSpeed = 5;
		
		public Camera ()
		{
		}
		
		public static float GetScrollSpeed()
		{
			return s_scrollSpeed;
		}
		
		public static void SetScrollSpeed(float newScrollSpeed)
		{
			s_scrollSpeed = newScrollSpeed;
		}
		
		public float Fov {
			get {
				return this.m_fov;
			}
			set {
				m_fov = value;
			}
		}

		public GridCoord GetGridPosition()
		{
			return new GridCoord(m_gridPosX, m_gridPosY);
		}
	}
}

