using System;
using System.Collections.Generic;
using Gtk;
namespace Undersea
{
	public abstract class Renderer
	{
		public Renderer ()
		{
		}
		
		protected Grid m_grid;
		protected Camera m_camera = new Camera();
		protected int m_windowSizeX;
		protected int m_windowSizeY;
		protected int m_gridSizeX;
		protected int m_gridSizeY;
		protected DateTime m_lastFrame;
		protected List<RenderObject> m_renderObjects = new List<RenderObject>();
		
		public enum Axis
		{
			X,
			Y,
			Z
		}
		
		public WindowCoord GridToWindowCoords(GridCoord gridCoord)
		{
			float windowCoordX = gridCoord.X * (m_windowSizeX / m_gridSizeX);
			float windowCoordY = gridCoord.Y * (m_windowSizeY / m_gridSizeY);
			return new WindowCoord(windowCoordX, windowCoordY);
		}
		
		public GridCoord WindowToGridCoords(WindowCoord windowCoord)
		{
			float gridCoordX = windowCoord.X * (m_gridSizeX / m_windowSizeX);
			float gridCoordY = windowCoord.Y * (m_gridSizeY / m_windowSizeY);
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

		public abstract void DrawLine(GridCoord pointStart, GridCoord pointEnd, System.Drawing.Color colour);
		public abstract void DrawText(GridCoord point, int size, string text, System.Drawing.Color colour);			
		public abstract void DrawSplash();
		public abstract void ClearSplash();
		protected abstract void BeginRender();
		protected abstract void EndRender();
		
		public static Renderer GetRenderer()
		{
			return MainWindow.GetRenderer();
		}
	}
}

