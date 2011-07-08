using System;
using System.Collections;
using System.Threading;
using Undersea;
using Tao.Sdl;

public class MainWindow
{
	private static int s_maxFPS = 30;
	SdlGfx.FPSmanager fpsManager = new SdlGfx.FPSmanager();
	private bool m_quit = false;
	
	public MainWindow ()
	{
		InitSDL();
		InitGame();
		// Declare a winner.
	}
	
	public void Run()
	{
		while ((!GameRules.GetGameRules().CheckGameEnded())
		       &&
		       (!m_quit))
		{
			HandleKeys();
			MainLoop();
		}
		
		Sdl.SDL_Quit();
	}
	
	public static Undersea.Renderer GetRenderer()
	{
		return s_renderer;
	}
	
	private static Undersea.Renderer s_renderer; 

	public void InitSDL() 
	{
		s_renderer = new Renderer2D(640,480);
		Sdl.SDL_WM_SetCaption("Octopus Castle View", "");
		// Enable Unicode
        Sdl.SDL_EnableUNICODE( 1 );
		InitFPSManager();
	}
	
	private unsafe void InitFPSManager()
	{
		fixed(SdlGfx.FPSmanager* man = &fpsManager)
		{
			// Framerate management.
			SdlGfx.SDL_initFramerate((IntPtr)man);
			SdlGfx.SDL_setFramerate((IntPtr)man, s_maxFPS);
		}
	}
	
	private void InitGame()
	{
		GameRules rules = new GameRulesStandard(100, 100);
		GameRules.StartNewGame(rules);
	}
	
	private void MainLoop()
	{
		GameRules.GetGameRules().Process();
		GetRenderer().Render();
		Snooze();
	}
	
	private void MenuLoop()
	{
		GetRenderer().Render();
		Snooze();
	}
	
	private unsafe void Snooze()
	{
		// Limit the framerate by snoozing every frame. Could possibly delegate this to SdlGfx.
		/*
		long ticksPerFrame = TimeSpan.TicksPerSecond / s_maxFPS;
		long ticksThisFrame = DateTime.Now.Ticks - GetRenderer().LastFrame.Ticks;
		if (ticksThisFrame < ticksPerFrame) 
		{
			Thread.Sleep((int)((ticksPerFrame - ticksThisFrame) / TimeSpan.TicksPerMillisecond));
		}*/
		fixed (SdlGfx.FPSmanager* man = &fpsManager)
		{
		SdlGfx.SDL_framerateDelay((IntPtr)man);
		}
	}
	
	private void HandleKeys()
	{
		Sdl.SDL_Event thisevent = new Sdl.SDL_Event();
		while (Sdl.SDL_PollEvent(out thisevent) > 0)
		{
			switch (thisevent.type)
			{
				case Sdl.SDL_KEYDOWN:
					if (thisevent.key.keysym.sym == Convert.ToInt32('q'))
						m_quit = true;
					break;
				    
				case Sdl.SDL_QUIT:
					m_quit = true;
					break;
			}
		}
	}
}

