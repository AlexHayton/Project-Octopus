using System;
using System.Collections.Generic;
using Gtk;
namespace Undersea
{
	public abstract class Renderer
	{		
		protected Grid m_grid;
		protected Camera m_camera = new Camera();
		protected short m_windowSizeX;
		protected short m_windowSizeY;
		protected int m_gridSizeX;
		protected int m_gridSizeY;
		protected DateTime m_lastFrame;
		protected List<RenderObject> m_renderObjects = new List<RenderObject>();
		protected Dictionary<string, IntPtr> m_textures = new Dictionary<string, IntPtr>();
		
		public enum Axis
		{
			X,
			Y,
			Z
		}
		
		public WindowCoord GridToWindowCoords(GridCoord gridCoord)
		{
			GridCoord camerapos = m_camera.GetGridPosition();
			float cameraTopLeftX = camerapos.X - m_camera.ZoomLevelX/2;
			float cameraTopLeftY = camerapos.Y - m_camera.ZoomLevelY/2;
			float windowCoordX = (gridCoord.X-cameraTopLeftX) * (m_windowSizeX / m_camera.ZoomLevelX);
			float windowCoordY = (gridCoord.Y-cameraTopLeftY) * (m_windowSizeY / m_camera.ZoomLevelY);
			return new WindowCoord(windowCoordX, windowCoordY);
		}
		
		public GridCoord WindowToGridCoords(WindowCoord windowCoord)
		{
			GridCoord camerapos = m_camera.GetGridPosition();
			float cameraTopLeftX = camerapos.X - m_camera.ZoomLevelX/2;
			float cameraTopLeftY = camerapos.Y - m_camera.ZoomLevelY/2;	
			float gridCoordX = cameraTopLeftX + (windowCoord.X * (m_camera.ZoomLevelX / m_windowSizeX));
			float gridCoordY = cameraTopLeftY + (windowCoord.Y * (m_camera.ZoomLevelY / m_windowSizeY));
			return new GridCoord(gridCoordX, gridCoordY);
		}
		
		public void AddRenderObject(RenderObject newobject)
		{
			// Store the grid if one is added.
			if (newobject is Grid)
			{
				m_grid = (Grid)newobject;
				m_gridSizeX = m_grid.SizeX;
				m_gridSizeY = m_grid.SizeY;
				m_camera.SetGridSize(m_gridSizeX, m_gridSizeY);
			}
			
			if (m_renderObjects.Contains(newobject))
			{
			    // Do nothing
			}
			else
			{
			    m_renderObjects.Add(newobject);
			}
		}
		
		public void RemoveRenderObject(RenderObject oldobject)
		{
			m_renderObjects.Remove(oldobject);
		}
		
		public void Render()
		{
			BeginRender();
			
			foreach (RenderObject target in m_renderObjects)
			{
				target.Draw();
			}
			
			EndRender();
			m_lastFrame = DateTime.Now;
		}
		
		public DateTime LastFrame {
			get {
				return this.m_lastFrame;
			}
		}

		public Grid Grid {
			get {
				return this.m_grid;
			}
		}

		public Camera Camera {
			get {
				return this.m_camera;
			}
		}

		public abstract void DrawLine(GridCoord pointStart, GridCoord pointEnd, System.Drawing.Color colour);
		public abstract void DrawText(GridCoord point, int size, string text, System.Drawing.Color colour);			
		public abstract void CacheTexture(string texture, short width, short height);
		public abstract void DrawImage(GridCoord point, string image, short width, short height);
		public abstract void DrawSplash();
		protected abstract void BeginRender();
		protected abstract void EndRender();
		
		public static Renderer GetRenderer()
		{
			return MainWindow.GetRenderer();
		}
	}
}

