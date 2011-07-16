using System;
namespace Undersea
{
	public class Camera : GridObject
	{
		// Roughly approximates to number of grid squares visible, assuming a square viewport.
		private float m_zoomLevelX = 20;
		private float m_zoomLevelY = 20;
		private float m_gridPosX = 0;
		private float m_gridPosY = 0;
		private float m_gridSizeX = 0;
		private float m_gridSizeY = 0;
		private float m_scrollSpeed = 5;
		
		public Camera ()
		{
			m_gridPosX = m_zoomLevelX/2;
			m_gridPosY = m_zoomLevelY/2;
		}
		
		public float ScrollSpeed {
			get {
				return this.m_scrollSpeed;
			}
			set {
				m_scrollSpeed = value;
			}
		}

		public void ScrollLeft(int milliseconds)
		{
			m_gridPosX -= m_scrollSpeed*((float)milliseconds/1000.0f);
			EdgeChecks();
		}
		
		public void ScrollRight(int milliseconds)
		{
			m_gridPosX += m_scrollSpeed*((float)milliseconds/1000.0f);
			EdgeChecks();
		}
		
		public void ScrollUp(int milliseconds)
		{
			m_gridPosY -= m_scrollSpeed*((float)milliseconds/1000.0f);
			EdgeChecks();
		}
		
		public void ScrollDown(int milliseconds)
		{
			m_gridPosY += m_scrollSpeed*((float)milliseconds/1000.0f);
			EdgeChecks();
		}
		
		private void EdgeChecks()
		{
			// Stop the camera going off the edges of the map!
			if (m_gridPosX < m_zoomLevelX/2)
				m_gridPosX = m_zoomLevelX/2;	
			if (m_gridPosY < m_zoomLevelY/2)
				m_gridPosY = m_zoomLevelY/2;	
			if (m_gridPosX > m_gridSizeX - m_zoomLevelX/2)
				m_gridPosX = m_gridSizeX - m_zoomLevelX/2;
			if (m_gridPosY > m_gridSizeY - m_zoomLevelY/2)
				m_gridPosY = m_gridSizeY - m_zoomLevelY/2;
		}
		
		public void SetGridSize(int width, int height)
		{
			m_gridSizeX = width;
			m_gridSizeY = height;
			EdgeChecks();
		}
		
		public void SetZoomLevel(float zoomX, float zoomY)
		{
			m_zoomLevelX = zoomX;
			m_zoomLevelY = zoomY;
			EdgeChecks();
		}
		
		public float ZoomLevelX {
			get {
				return this.m_zoomLevelX;
			}
		}
		
		public float ZoomLevelY {
			get {
				return this.m_zoomLevelY;
			}
		}	

		public GridCoord GetGridPosition()
		{
			return new GridCoord(m_gridPosX, m_gridPosY);
		}
		
		public void SetGridPosition(GridCoord coord)
		{
			m_gridPosX = coord.X;
			m_gridPosY = coord.Y;
		}
	}
}

