namespace GridMap
{
	public partial class GridMap
	{
		public static void Set(List<List<string>> TwoDMap, int x, int y, string name)
		{
			TwoDMap[y][x] = name;
		}
	}
}
