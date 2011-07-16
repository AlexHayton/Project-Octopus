using System;
using System.Collections;
using System.Threading;
using Undersea;
using Tao.Sdl;

public class MainWindow
{
	private static int s_maxFPS = 30;
	private SdlGfx.FPSmanager m_fpsManager = new SdlGfx.FPSmanager();
	private KeyHandler m_keyHandler = new KeyHandler();
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
		fixed(SdlGfx.FPSmanager* man = &m_fpsManager)
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
		rules.KeyHandler = SetupKeyHandler();
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
		fixed (SdlGfx.FPSmanager* man = &m_fpsManager)
		{
		SdlGfx.SDL_framerateDelay((IntPtr)man);
		}
	}
	
	private KeyHandler SetupKeyHandler()
	{ 
		// Reinstantiate the handler.
		m_keyHandler = new KeyHandler();
		
		// Start at the end
		KeyAction quit = new KeyAction(this.Quit, null, null);
		m_keyHandler.AddAction("q", quit);
		
		// Scrolling
		KeyAction scrollup = new KeyAction(null, null, GetRenderer().Camera.ScrollUp);
		m_keyHandler.AddAction("uparrow", scrollup);
		KeyAction scrolldown = new KeyAction(null, null, GetRenderer().Camera.ScrollDown);
		m_keyHandler.AddAction("downarrow", scrolldown);
		KeyAction scrollleft = new KeyAction(null, null, GetRenderer().Camera.ScrollLeft);
		m_keyHandler.AddAction("leftarrow", scrollleft);
		KeyAction scrollright = new KeyAction(null, null, GetRenderer().Camera.ScrollRight);
		m_keyHandler.AddAction("rightarrow", scrollright);
		
		return m_keyHandler;
	}
		                               
	public void Quit()
	{
		m_quit = true;
	}
	
	private string ConvertKeystroke(int keynum)
	{
		string keystring = "";
		switch (keynum)
		{
			case 273:
				keystring = "uparrow";
				break;
			
			case 274:
				keystring = "downarrow";
				break;
			
			case 276:
				keystring = "leftarrow";
				break;
			
			case 275:
				keystring = "rightarrow";
				break;
			
			default:
				keystring = Convert.ToChar(keynum).ToString();
				break;
		}
		
		return keystring;
	}
	
	private void HandleKeys()
	{
		Sdl.SDL_Event thisevent = new Sdl.SDL_Event();
		while (Sdl.SDL_PollEvent(out thisevent) > 0)
		{
			switch (thisevent.type)
			{
				case Sdl.SDL_KEYDOWN:
					m_keyHandler.KeyDown(ConvertKeystroke(thisevent.key.keysym.sym));
					break;
				
				case Sdl.SDL_KEYUP:
					m_keyHandler.KeyUp(ConvertKeystroke(thisevent.key.keysym.sym));
					break;
				    
				case Sdl.SDL_QUIT:
					this.Quit();
					break;
			}
		}
	}
}

