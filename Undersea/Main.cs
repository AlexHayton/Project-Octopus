using System;
using Gtk;

namespace Undersea
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			//Application.Run ();
			
			win.Run();
		}
	}
}

