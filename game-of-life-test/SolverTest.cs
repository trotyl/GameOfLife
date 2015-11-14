using NUnit.Framework;
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
		public void count_should_have_correct_for_1_times_1_grid()
		{
			var grid1 = new bool[][] 
			{ 
				new[] { true }, 
			};
			var grid2 = new bool[][] 
			{ 
				new[] { false }, 
			};

			Assert.AreEqual (0, Solver.CountNeighbors (grid1, 0, 0));
			Assert.AreEqual (0, Solver.CountNeighbors (grid2, 0, 0));
		}
	}
}

