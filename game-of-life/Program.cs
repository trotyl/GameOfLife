using System;

namespace gameoflife
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}

		public static string Run (string input)
		{
			return input.Parse ().Generate ().Format ();
		}
	}
}
