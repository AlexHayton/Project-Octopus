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
		private float m_overlayAlpha = 0.0f;
		
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
		
		public bool IsVisible(GridCoord pointTopLeft, GridCoord pointTopRight, GridCoord pointBottomRight, GridCoord pointBottomLeft)
		{
			return true;
		}
		
		public override void DrawLine(GridCoord pointStart, GridCoord pointEnd, System.Drawing.Color colour)
		{
			if (IsVisible(pointStart, pointEnd))
			{
				WindowCoord wpointStart = GridToWindowCoords(pointStart);
				WindowCoord wpointEnd = GridToWindowCoords(pointEnd);
				int result = SdlGfx.aalineRGBA(m_surface, (short)wpointStart.X, (short)wpointStart.Y, (short)wpointEnd.X, (short)wpointEnd.Y, colour.R, colour.G, colour.B, colour.A);
				if (result == -1)
				{
					throw new RenderException("Could not draw the line");
				}
			}
		}
		
		public override void DrawText(GridCoord point, int size, string text, System.Drawing.Color colour)
		{
			// Convert the colour
			Sdl.SDL_Color sdlcolour = new Sdl.SDL_Color(colour.R, colour.G, colour.B, colour.A);
			
			// Render the text to a surface
			IntPtr renderPtr = SdlTtf.TTF_RenderText_Solid(m_mainfont, text, sdlcolour);
			Sdl.SDL_Surface fontSurface = (Sdl.SDL_Surface)System.Runtime.InteropServices.Marshal.PtrToStructure(renderPtr, typeof(Sdl.SDL_Surface));
			
			// Calculate visibility
			WindowCoord wpoint = GridToWindowCoords(point);
			GridCoord toprightpoint = WindowToGridCoords(new WindowCoord(wpoint.X + fontSurface.w, wpoint.Y));
			GridCoord bottomrightpoint = WindowToGridCoords(new WindowCoord(wpoint.X + fontSurface.w, wpoint.Y + fontSurface.h));
			GridCoord bottomleftpoint = WindowToGridCoords(new WindowCoord(wpoint.X, wpoint.Y + fontSurface.h));
			
			if (IsVisible(point,toprightpoint,bottomrightpoint,bottomleftpoint))
			{
				// Then blit this to the main window
				Sdl.SDL_Rect fontRect = new Sdl.SDL_Rect(0, 0, (short)fontSurface.w, (short)fontSurface.h);
				Sdl.SDL_Rect dstRect = new Sdl.SDL_Rect((short)wpoint.X,(short)wpoint.Y,(short)fontSurface.w,(short)fontSurface.h);
				Sdl.SDL_BlitSurface(renderPtr, ref fontRect, m_surface, ref dstRect);
			}
			
			// Clean up the mess
			Sdl.SDL_FreeSurface(renderPtr);
		}
		
		public override void DrawSplash()
		{
			IntPtr imagePtr = SdlImage.IMG_Load("images/Octo-Image.jpg");
			Sdl.SDL_Surface imageSurface = (Sdl.SDL_Surface)System.Runtime.InteropServices.Marshal.PtrToStructure(imagePtr, typeof(Sdl.SDL_Surface));
			Sdl.SDL_Rect imageRect = new Sdl.SDL_Rect(0, 0, (short)imageSurface.w, (short)imageSurface.h);
			Sdl.SDL_Rect dstRect = new Sdl.SDL_Rect(100,100,(short)imageSurface.w,(short)imageSurface.h);
			Sdl.SDL_BlitSurface(imagePtr, ref imageRect, m_surface, ref dstRect);
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

