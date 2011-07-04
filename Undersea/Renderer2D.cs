using System;
using Tao.Sdl;
namespace Undersea
{
	public class Renderer2D : Renderer
	{
		private IntPtr m_surface;
		private string m_fontdirectory;
		private string m_mainfontname;
		private IntPtr m_mainfont;
		
		public Renderer2D (IntPtr surface)
		{
			m_surface = surface;
			
			SdlTtf.TTF_Init();
			
			// Some bits here are OS-dependent.
			// TODO: Multi-platform fonts.
			/*if (os.Platform.ToString().ToUpper().Contains("WINDOWS"))
			{
				m_fontdirectory = @"C:\Windows\Fonts";
				m_textfont = "";
			}
			else if (os.Platform.ToString().ToUpper().Contains("APPLE"))
			{
				m_fontdirectory = "/var/fonts";
				m_textfont = "";
			}
			else
			{*/
				m_fontdirectory = "/usr/share/fonts/truetype/";
				m_mainfontname = "freefont/FreeSans.ttf";
			/*}*/
			
			m_mainfont = SdlTtf.TTF_OpenFont(m_fontdirectory + m_mainfontname, 12);
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
			SdlGfx.aalineColor(m_surface, (short)pointStart.X, (short)pointStart.Y, (short)pointEnd.X, (short)pointEnd.Y, 0);
		}
		
		public override void DrawText(GridCoord point, int size, string text, System.Drawing.Color colour)
		{
			// Convert the colour
			Sdl.SDL_Color sdlcolour = new Sdl.SDL_Color(colour.R, colour.G, colour.B, colour.A);
			SdlTtf.TTF_RenderUNICODE_Blended(m_mainfont, text, sdlcolour);
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

