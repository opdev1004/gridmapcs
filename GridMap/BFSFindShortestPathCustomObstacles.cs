namespace GridMap
{
	public partial class GridMap
	{
		public static List<(int, int, string)> BFSFindShortestPath(List<List<string>> TwoDMap, (int y, int x) start, (int y, int x) goal, List<(int y, int x)> obstacles)
		{
			int numRows = TwoDMap[0].Count;
			int numCols = TwoDMap.Count;
			var directions = new List<(int, int)> { (1, 0), (0, 1), (-1, 0), (0, -1) };

			var queue = new Queue<((int, int) position, List<(int, int, string)> path)>();
			var visited = new HashSet<(int, int)>();
			queue.Enqueue((start, new List<(int, int, string)> { (start.y, start.x, TwoDMap[start.y][start.x]) }));
			visited.Add(start);

			while (queue.Count > 0)
			{
				var (current, path) = queue.Dequeue();

				if (current == goal)
				{
					return path;
				}

				foreach (var direction in directions)
				{
					int newY = current.Item1 + direction.Item1;
					int newX = current.Item2 + direction.Item2;

					if (newX >= 0 && newX < numRows && newY >= 0 && newY < numCols)
					{
						var newPosition = (newY, newX);
						if (!visited.Contains(newPosition) && !obstacles.Contains(newPosition))
						{
							visited.Add(newPosition);
							var newPath = new List<(int, int, string)>(path)
							{
								(newY, newX, TwoDMap[newY][newX])
							};
							queue.Enqueue((newPosition, newPath));
						}
					}
				}
			}

			return [];
		}
	}
}
