﻿namespace GridMap
{
	public partial class GridMap
	{
		public static List<(int y, int x, string name)> EAStarShortestPath(List<List<string>> TwoDMap, (int y, int x) start, (int y, int x) goal, List<string> obstacles)
		{
			int numRows = TwoDMap[0].Count;
			int numCols = TwoDMap.Count;
			var directions = new List<(int, int)> { (0, 1), (1, 0), (0, -1), (-1, 0) };

			var openSet = new SortedSet<(double fScore, (int, int) position)>(Comparer<(double, (int, int))>.Create((a, b) => a.Item1 == b.Item1 ? a.Item2.CompareTo(b.Item2) : a.Item1.CompareTo(b.Item1)));
			var cameFrom = new Dictionary<(int, int), (int, int)>();
			var gScore = new Dictionary<(int, int), int> { [start] = 0 };
			var fScore = new Dictionary<(int, int), double> { [start] = EuclideanHeuristic(start, goal) };

			openSet.Add((fScore[start], start));

			while (openSet.Count > 0)
			{
				var current = openSet.Min.position;
				if (current == goal)
				{
					return ReconstructPath(cameFrom, current, TwoDMap);
				}

				openSet.Remove(openSet.Min);

				foreach (var direction in directions)
				{
					int newY = current.Item1 + direction.Item1;
					int newX = current.Item2 + direction.Item2;
					var neighbor = (newY, newX);

					if (newX >= 0 && newX < numRows && newY >= 0 && newY < numCols && !obstacles.Contains(TwoDMap[newY][newX]))
					{
						int tentativeGScore = gScore[current] + 1;

						if (!gScore.TryGetValue(neighbor, out int value) || tentativeGScore < value)
						{
							cameFrom[neighbor] = current;
							value = tentativeGScore;
							gScore[neighbor] = value;
							fScore[neighbor] = gScore[neighbor] + EuclideanHeuristic(neighbor, goal);

							if (!openSet.Contains((fScore[neighbor], neighbor)))
							{
								openSet.Add((fScore[neighbor], neighbor));
							}
						}
					}
				}
			}

			return [];
		}

	}
}
