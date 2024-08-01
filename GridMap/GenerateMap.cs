namespace GridMap
{
	public partial class GridMap
	{
		public static List<List<string>> GenerateMap(int y, int x, string initName = "empty")
		{
			List<List<string>> map = [];
			for (int i = 0; i < y; i++)
			{
				List<string> row = [];
				for (int j = 0; j < x; j++) row.Add(initName);
				map.Add(row);
			}

			return map;
		}
	}
}
