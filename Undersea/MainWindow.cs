using System;
using System.Collections;
using System.Threading;
using Gtk;
using Undersea;
using Tao.Sdl;

public partial class MainWindow : Gtk.Window
{
	private static int s_maxFPS = 30;
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		InitSDL();
		InitGame();
		
		while (!GameRules.GetGameRules().CheckGameEnded())
		{
			MainLoop();
		}
		
		// Declare a winner.
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
	
	private void Snooze()
	{
		// Limit the framerate by snoozing every frame. Could possibly delegate this to SdlGfx.
		long ticksPerFrame = TimeSpan.TicksPerSecond / s_maxFPS;
		long ticksThisFrame = DateTime.Now.Ticks - GetRenderer().LastFrame.Ticks;
		if (ticksThisFrame < ticksPerFrame) 
		{
			Thread.Sleep((int)((ticksPerFrame - ticksThisFrame) / TimeSpan.TicksPerMillisecond));
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Sdl.SDL_Quit();
		Application.Quit ();
		a.RetVal = true;
	}
	
	
}

