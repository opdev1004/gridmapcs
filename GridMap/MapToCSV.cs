
using System.Text;

namespace GridMap
{
	public partial class GridMap
	{
		public static string MapToCSV(List<List<string>> grid, string delimiter = ",", string quotechar = "\"", string newline = "\n")
		{
			if (grid == null || grid.Count == 0) return string.Empty;

			StringBuilder csvBuilder = new();

			foreach (var row in grid)
			{
				for (int i = 0; i < row.Count; i++)
				{
					string field = row[i];

					if (field.Contains(delimiter) || field.Contains(quotechar) || field.Contains('\n'))
					{
						field = field.Replace(quotechar, quotechar + quotechar);
						field = quotechar + field + quotechar;
					}

					csvBuilder.Append(field);

					if (i < row.Count - 1)
					{
						csvBuilder.Append(delimiter);
					}
				}

				csvBuilder.Append(newline);
			}

			return csvBuilder.ToString();
		}

	}
}
