namespace GridMap
{
	public partial class GridMap
	{
		public static string? GetName(List<List<string>> TwoDMap, int y, int x)
		{
			if (y < 0 || y >= TwoDMap.Count || x < 0 || x >= TwoDMap[0].Count) return null;

			return TwoDMap[y][x];
		}
	}
}
