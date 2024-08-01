namespace GridMap
{
	public partial class GridMap
	{
		public static string? GetBottomLeft(List<List<string>> TwoDMap, int y, int x, int count = 1)
		{
			if (count < 1 || y < 0 || y + count >= TwoDMap.Count || x - count < 0 || x >= TwoDMap[0].Count) return null;

			return TwoDMap[y + count][x - count];
		}
	}
}