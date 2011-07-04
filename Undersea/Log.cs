using System;
using System.IO;
namespace Undersea
{
	public class Log
	{
		public enum LogLevel
		{
			Info,
			Warning,
			Error,
			Critical
		}
		
		private static bool s_LogOpened = false;
		
		public static void WriteToLog(LogLevel logginglevel, string message)
		{
			if (!s_LogOpened)
			{
				s_LogOpened = true;
			}
			
			Console.WriteLine(message);
		}
	}
}

