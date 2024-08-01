namespace GridMap
{
	public partial class GridMap
	{
		public static string? GetLeft(List<List<string>> TwoDMap, int y, int x, int count = 1)
		{
			if (count < 1 || y < 0 || y >= TwoDMap.Count || x - count < 0 || x >= TwoDMap.Count) return null;

			return TwoDMap[y][x - count];
		}
	}
}
