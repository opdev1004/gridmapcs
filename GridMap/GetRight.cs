namespace GridMap
{
	public partial class GridMap
	{
		public static string? GetRight(List<List<string>> TwoDMap, int y, int x, int count = 1)
		{
			if (count < 1 || y < 0 || y >= TwoDMap.Count || x < 0 || x + count >= TwoDMap[0].Count) return null;

			return TwoDMap[y][x + count];
		}

	}
}
