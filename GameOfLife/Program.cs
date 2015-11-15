using System;

namespace Gameoflife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static string Run(string input)
        {
            return input.Parse().Generate().Format();
        }
    }
}
