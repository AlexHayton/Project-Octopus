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
		
		public Renderer2D (int width, int height)
		{
			m_windowSizeX = width;
			m_windowSizeY = height;
			
			// Initialise Sdl.
			Sdl.SDL_Init(Sdl.SDL_INIT_VIDEO);
			Sdl.SDL_SetVideoMode(m_windowSizeX, m_windowSizeY, 16, Sdl.SDL_DOUBLEBUF|Sdl.SDL_ANYFORMAT);
			m_surface = Sdl.SDL_GetVideoSurface();
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
		
		public override void DrawLine(GridCoord pointStart, GridCoord pointEnd, System.Drawing.Color colour)
		{
			WindowCoord wpointStart = GridToWindowCoords(pointStart);
			WindowCoord wpointEnd = GridToWindowCoords(pointEnd);
			int result = SdlGfx.aalineRGBA(m_surface, (short)wpointStart.X, (short)wpointStart.Y, (short)wpointEnd.X, (short)wpointEnd.Y, colour.R, colour.G, colour.B, colour.A);
			if (result == -1)
			{
				throw new RenderException("Could not draw the line");
			}
		}
		
		public override void DrawText(GridCoord point, int size, string text, System.Drawing.Color colour)
		{
			// Convert the colour
			//Sdl.SDL_Color sdlcolour = new Sdl.SDL_Color(colour.R, colour.G, colour.B, colour.A);
			//int result = SdlTtf.TTF_RenderUNICODE_Blended(m_mainfont, text, sdlcolour);
		}
		
		public override void DrawSplash()
		{
			IntPtr image = SdlImage.IMG_Load("");
			
		}
		
		public override void ClearSplash()
		{
		}
		
		protected override void BeginRender()
		{
		}
		
		protected override void EndRender()
		{
			Sdl.SDL_UpdateRect(m_surface, 0, 0, m_windowSizeX, m_windowSizeY);
		} 
	}
}

