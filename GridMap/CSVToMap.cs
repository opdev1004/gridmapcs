
using System.Text;

namespace GridMap
{
	public partial class GridMap
	{
		public static List<List<string>>? CSVToMap(string csvdata, string delimiter = ",", string quotechar = "\"")
		{
			if (string.IsNullOrEmpty(csvdata)) return null;

			List<List<string>> grid = [];
			StringBuilder fieldBuilder = new();
			List<string> row = [];
			bool inQuotes = false;

			for (int i = 0; i < csvdata.Length; i++)
			{
				char currentChar = csvdata[i];
				char nextChar = (i + 1 < csvdata.Length) ? csvdata[i + 1] : '\0';

				if (currentChar.ToString() == quotechar)
				{
					if (inQuotes && nextChar.ToString() == quotechar)
					{
						fieldBuilder.Append(quotechar);
						i++;
					}
					else
					{
						inQuotes = !inQuotes;
					}
				}
				else if (currentChar.ToString() == delimiter && !inQuotes)
				{
					row.Add(fieldBuilder.ToString());
					fieldBuilder.Clear();
				}
				else if ((currentChar == '\r' && nextChar == '\n' || currentChar == '\n') && !inQuotes)
				{
					row.Add(fieldBuilder.ToString());
					fieldBuilder.Clear();
					grid.Add(row);
					row = [];
					if (currentChar == '\r') i++;
				}
				else
				{
					fieldBuilder.Append(currentChar);
				}
			}

			row.Add(fieldBuilder.ToString());
			grid.Add(row);

			return grid;
		}

	}
}
