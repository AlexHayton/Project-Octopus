using System;
using Tao.Sdl;
namespace Undersea
{
	public class Renderer2D : Renderer
	{
		private IntPtr m_surface;
		
		public Renderer2D (IntPtr surface)
		{
			m_surface = surface;
		}
		
		public bool IsVisible(GridCoord coord)
		{
			return true;
		}
		
		public bool IsVisible(GridCoord pointStart, GridCoord pointEnd)
		{
			return true;
		}
		
		public bool IsVisible(GridCoord pointX1, GridCoord pointX2, GridCoord pointY1, GridCoord pointY2)
		{
			return true;
		}
		
		public override void DrawLine(GridCoord pointStart, GridCoord pointEnd)
		{
			SdlGfx.aalineColor(m_surface, pointStart.X, pointStart.Y, pointEnd.X, pointEnd.Y);
		}
		
		public override void DrawText(GridCoord point, int size, string text)
		{
		}
		
		public override void DrawSplash()
		{
			IntPtr image = SdlImage.IMG_Load("");
			
		}
		
		public override void ClearSplash()
		{
		}
	}
}

