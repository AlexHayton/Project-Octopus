using System;
using Gtk;
using System.Drawing.Drawing2D;

public partial class MainWindow : Gtk.Window
{
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	public static Undersea.Renderer GetRenderer()
	{
		return s_renderer;
	}
	
	private static Undersea.Renderer s_renderer; 

	public void Init() 
	{
		s_renderer = new Undersea.Renderer2D(image1);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}

