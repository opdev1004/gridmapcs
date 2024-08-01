namespace GridMap
{
	public partial class GridMap
	{
		public static double EuclideanHeuristic((int y, int x) to, (int y, int x) from)
		{
			double dy = Math.Abs(to.y - from.y);
			double dx = Math.Abs(to.x - from.x);
			return Math.Sqrt(dy * dy + dx * dx);
		}
	}
}
