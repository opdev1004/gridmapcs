namespace GridMap
{
	public partial class GridMap
	{
		public static List<(int, int, string)> ReconstructPath(Dictionary<(int, int), (int, int)> cameFrom, (int, int) current, List<List<string>> TwoDMap)
		{
			var totalPath = new List<(int, int, string)>();
			while (cameFrom.ContainsKey(current))
			{
				totalPath.Insert(0, (current.Item1, current.Item2, TwoDMap[current.Item1][current.Item2]));
				current = cameFrom[current];
			}
			totalPath.Insert(0, (current.Item1, current.Item2, TwoDMap[current.Item1][current.Item2]));
			return totalPath;
		}



	}
}
