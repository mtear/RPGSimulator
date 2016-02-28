using System;

namespace TestOSX
{
	public class Utility
	{
		public Utility ()
		{
		}

		public static bool RecordOutput = false;

		public static void WriteLine(String message){
			if(!RecordOutput) return;
			Console.WriteLine (message);
		}
	}
}

