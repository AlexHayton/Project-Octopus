using System;
using Gtk;
namespace Undersea
{
	public class Renderer2D : Renderer
	{
		private DrawingArea m_drawingarea;
		
		public Renderer2D (DrawingArea drawingarea)
		{
			m_drawingarea = drawingarea;
		}
		
		public override void DrawLine(GridCoord pointStart, GridCoord pointEnd)
		{
			Draw.PaintHLine(Style.PaintHLine); 
		}
		
		public override void DrawText(GridCoord point, int size, string text)
		{
		}
	}
}

