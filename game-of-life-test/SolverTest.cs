using NUnit.Framework;
using System;
using gameoflife;

namespace gameoflifetest
{
	[TestFixture]
	public class SolverParseTest
	{
		[Test]
		public void parse_should_have_the_right_result()
		{
			var input = @"3 3
..*
.*.
...";
			var result = input.Parse();

			Assert.AreEqual(false, result[0][0]);
			Assert.AreEqual(false, result[0][1]);
			Assert.AreEqual(true, result[0][2]);
			Assert.AreEqual(false, result[1][0]);
			Assert.AreEqual(true, result[1][1]);
			Assert.AreEqual(false, result[1][2]);
			Assert.AreEqual(false, result[2][0]);
			Assert.AreEqual(false, result[2][1]);
			Assert.AreEqual(false, result[2][2]);
		}


	}

	[TestFixture]
	public class SolverGenerateTest
	{
		[Test]
		public void generate_should_have_correct_result_for_live_cell_with_less_than_two_live_neighbor()
		{
			var original = new bool[][] 
			{ 
				new[] { false, false, true }, 
				new[] { false, true, false }, 
				new[] { false, false, false }
			};
			var result = original.Generate();

			Assert.AreEqual(false, result[0][0]);
			Assert.AreEqual(false, result[0][1]);
			Assert.AreEqual(false, result[0][2]);
			Assert.AreEqual(false, result[1][0]);
			Assert.AreEqual(false, result[1][1]);
			Assert.AreEqual(false, result[1][2]);
			Assert.AreEqual(false, result[2][0]);
			Assert.AreEqual(false, result[2][1]);
			Assert.AreEqual(false, result[2][2]);
		}
	}

	[TestFixture]
	public class SolverCountTest
	{
		[Test]
		public void count_should_have_correct_result_for_1_times_1_grid()
		{
			var grid1 = new bool[][] 
			{ 
				new[] { true }, 
			};
			var grid2 = new bool[][] 
			{ 
				new[] { false }, 
			};

			Assert.AreEqual (0, Solver.Count (grid1, 0, 0));
			Assert.AreEqual (0, Solver.Count (grid2, 0, 0));
		}

		[Test]
		public void count_should_have_correct_result_for_1_times_2_grid()
		{
			var grid1 = new bool[][] 
			{ 
				new[] { true, true }, 
			};
			var grid2 = new bool[][] 
			{ 
				new[] { true, false }, 
			};
			var grid3 = new bool[][] 
			{ 
				new[] { false, false }, 
			};

			Assert.AreEqual (1, Solver.Count (grid1, 0, 0));
			Assert.AreEqual (1, Solver.Count (grid1, 0, 1));
			Assert.AreEqual (0, Solver.Count (grid2, 0, 0));
			Assert.AreEqual (1, Solver.Count (grid2, 0, 1));
			Assert.AreEqual (0, Solver.Count (grid3, 0, 0));
			Assert.AreEqual (0, Solver.Count (grid3, 0, 1));
		}

		[Test]
		public void count_should_have_correct_result_for_2_times_2_grid()
		{
			var grid1 = new bool[][] 
			{ 
				new[] { true, true }, 
				new[] { true, true }, 
			};
			var grid2 = new bool[][] 
			{ 
				new[] { true, false }, 
				new[] { false, true }, 
			};

			Assert.AreEqual (3, Solver.Count (grid1, 0, 0));
			Assert.AreEqual (3, Solver.Count (grid1, 0, 1));
			Assert.AreEqual (3, Solver.Count (grid1, 1, 0));
			Assert.AreEqual (3, Solver.Count (grid1, 1, 1));
			Assert.AreEqual (1, Solver.Count (grid2, 0, 0));
			Assert.AreEqual (2, Solver.Count (grid2, 0, 1));
			Assert.AreEqual (2, Solver.Count (grid2, 1, 0));
			Assert.AreEqual (1, Solver.Count (grid2, 1, 1));
		}

		[Test]
		public void count_should_have_correct_result_for_3_times_3_grid()
		{
			var grid1 = new bool[][] 
			{ 
				new[] { true, false, true }, 
				new[] { false, true, false }, 
				new[] { true, false, true }, 
			};

			Assert.AreEqual (1, Solver.Count (grid1, 0, 0));
			Assert.AreEqual (4, Solver.Count (grid1, 1, 1));
			Assert.AreEqual (3, Solver.Count (grid1, 1, 2));
			Assert.AreEqual (1, Solver.Count (grid1, 2, 2));

		}
	}

	[TestFixture]
	public class SolverJudgeTest
	{
		[Test]
		public void judge_should_get_dead_for_live_cell_with_less_than_2_live_neighbor()
		{
			Assert.AreEqual (false, Solver.Judge(true, 0));
			Assert.AreEqual (false, Solver.Judge(true, 1));
		}

		[Test]
		public void judge_should_get_dead_for_live_cell_with_more_than_3_live_neighbor()
		{
			Assert.AreEqual (false, Solver.Judge(true, 4));
			Assert.AreEqual (false, Solver.Judge(true, 5));
			Assert.AreEqual (false, Solver.Judge(true, int.MaxValue));
		}

		[Test]
		public void judge_should_get_alive_for_live_cell_with_2_or_3_live_neighbor()
		{
			Assert.AreEqual (true, Solver.Judge(true, 2));
			Assert.AreEqual (true, Solver.Judge(true, 3));
		}


		[Test]
		public void judge_should_get_alive_for_dead_cell_with_3_live_neighbor()
		{
			Assert.AreEqual (true, Solver.Judge(false, 3));
		}

		[Test]
		public void judge_should_get_dead_for_dead_cell_with_not_3_live_neighbor()
		{
			Assert.AreEqual (false, Solver.Judge(false, 0));
			Assert.AreEqual (false, Solver.Judge(false, 1));
			Assert.AreEqual (false, Solver.Judge(false, 2));
			Assert.AreEqual (false, Solver.Judge(false, 4));
			Assert.AreEqual (false, Solver.Judge(false, 5));
			Assert.AreEqual (false, Solver.Judge(false, int.MaxValue));
		}
	}
}

