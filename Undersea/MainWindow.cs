using System;
using System.Collections;
using Gtk;
using Undersea;
using Tao.Sdl;

public partial class MainWindow : Gtk.Window
{
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		InitSDL();
		InitGame();
		MainLoop();
	}
	
	public static Undersea.Renderer GetRenderer()
	{
		return s_renderer;
	}
	
	private static Undersea.Renderer s_renderer; 

	public void InitSDL() 
	{
		// Initialise Sdl.
		Sdl.SDL_Init(Sdl.SDL_INIT_VIDEO);
		Sdl.SDL_SetVideoMode(640, 480, 16, Sdl.SDL_DOUBLEBUF|Sdl.SDL_ANYFORMAT);
		Sdl.SDL_WM_SetCaption("Octopus Castle View", "");
		
		s_renderer = new Renderer2D(Sdl.SDL_GetVideoSurface());
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
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Sdl.SDL_Quit();
		Application.Quit ();
		a.RetVal = true;
	}
	
	
}

