namespace GridMap
{
	public partial class GridMap
	{
		public static int ManhattanHeuristic((int y, int x) to, (int y, int x) from)
		{
			return Math.Abs(to.y - from.y) + Math.Abs(to.x - from.x);
		}
	}
}
