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
		
		protected int m_windowSizeX;
		protected int m_windowSizeY;
		protected int m_gridSizeX;
		protected int m_gridSizeY;
		protected List<RenderObject> m_renderObjects = new List<RenderObject>();
		
		public enum Axis
		{
			X,
			Y,
			Z
		}
		
		public float GridToWindowCoords(float gridCoord, Axis axis)
		{
			float windowSize, gridSize;
			switch (axis)
			{
			case Axis.X:
				windowSize = m_windowSizeX;
				gridSize = m_gridSizeX;
				break;
			default:
				windowSize = m_windowSizeY;
				gridSize = m_gridSizeY;
				break;
			}
			return gridCoord * (gridSize / windowSize);
		}	
		
		public float WindowToGridCoords(float windowCoord, Axis axis)
		{
			float windowSize, gridSize;
			switch (axis)
			{
			case Axis.X:
				windowSize = m_windowSizeX;
				gridSize = m_gridSizeX;
				break;
			default:
				windowSize = m_windowSizeY;
				gridSize = m_gridSizeY;
				break;
			}
			return windowCoord * (windowSize / gridSize);
		}
		
		public void AddRenderObject(RenderObject newobject)
		{
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
		
		public abstract void DrawLine(GridCoord pointStart, GridCoord pointEnd);
		public abstract void DrawText(GridCoord point, int size, string text);			
		public abstract void DrawSplash();
		public abstract void ClearSplash();
	}
}

