namespace UnitTest
{
	public class EAStarShortestPathAD
	{
		private static List<List<string>> CreateTestGrid()
		{
			return
			[
				["S", ".", ".", "#", ".", ".", "."],
				[".", "#", ".", ".", ".", "#", "."],
				[".", "#", ".", ".", ".", ".", "."],
				[".", ".", "#", "#", ".", ".", "."],
				["#", ".", "#", "G", ".", "#", "."]
			];
		}

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestFindShortestPath()
		{
			var grid = CreateTestGrid();
			var start = (0, 0); // 'S' position
			var goal = (4, 3); // 'G' position
			var obstacles = new List<string> { "#" };

			var expectedPath = new List<(int, int, string)>
			{
				(0, 0, "S"),
				(0, 1, "."),
				(1, 2, "."),
				(2, 3, "."),
				(3, 4, "."),
				(4, 3, "G")
			};

			var result = GridMap.GridMap.EAStarShortestPathAD(grid, start, goal, obstacles);

			foreach (var item in result)
			{
				Console.WriteLine($"{item.Item1}, {item.Item2}, {item.Item3}");
			}

			Assert.That(result, Is.EqualTo(expectedPath));
		}

		[Test]
		public void TestNoPathAvailable()
		{
			var grid = CreateTestGrid();
			var start = (0, 0); // 'S' position
			var goal = (6, 6); // An arbitrary unreachable position
			var obstacles = new List<string> { "#" };

			var result = GridMap.GridMap.EAStarShortestPathAD(grid, start, goal, obstacles);

			Assert.That(result, Is.Empty);
		}

		[Test]
		public void TestStartIsGoal()
		{
			var grid = CreateTestGrid();
			var start = (0, 0); // 'S' position
			var goal = (0, 0); // Start and goal are the same
			var obstacles = new List<string> { "#" };

			var expectedPath = new List<(int, int, string)>
			{
				(0, 0, "S")
			};

			var result = GridMap.GridMap.EAStarShortestPathAD(grid, start, goal, obstacles);

			Assert.That(result, Is.EqualTo(expectedPath));
		}
	}
}