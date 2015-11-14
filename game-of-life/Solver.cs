using System;
using System.Linq;

namespace gameoflife
{
	public static class Solver
	{
		public static bool[][] Parse(this string input) 
		{            
			return input
				.Split(Environment.NewLine.ToCharArray())
				.Skip(1)
				.Select(line => line.Select(c => c == '*'))
				.Select(line => line.ToArray())
				.ToArray();
		}

		public static bool[][] Generate(this bool[][] cellses)
		{
			return cellses
				.Select((cells, i) => cells.Select((cell, j) => new { Status = cell, Count = CountNeighbors(cellses, i, j) }))
				.Select(cellsWithCounts => cellsWithCounts.Select(cellWithCount => JudgeStatus(cellWithCount.Status, cellWithCount.Count)))
				.Select(cells => cells.ToArray())
				.ToArray();
		}

		public static string Format(this bool[][] cellses)
		{
			return null;
		}

		public static int CountNeighbors(bool[][] cells, int x, int y)
		{
			return Enumerable.Range (x == 0 ? 0 : -1, (x == cells.Length - 1 ? 1 : 2) - (x == 0 ? 0 : -1))
				.SelectMany (i => Enumerable.Range (y == 0 ? 0 : -1, (y == cells [0].Length - 1 ? 1 : 2) - (y == 0 ? 0 : -1)).Select (j => { Console.WriteLine($"{i} {j}"); return new { Dx = i, Dy = j };}))
				.Where (tuple => !(tuple.Dx == 0 && tuple.Dy == 0))
				.Aggregate (0, (sum, tuple) => sum + (cells [x + tuple.Dx] [y + tuple.Dy]? 1: 0));
		}

		public static bool JudgeStatus(bool status, int neighbors)
		{
			return false;
		}
	}
}

