namespace UnitTest
{
	public class CSVToMap
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void BasicCSVReturnsCorrectGrid()
		{
			string csvData = "A,B,C\nD,E,F\nG,H,I";
			List<List<string>> expected = new List<List<string>> {
				new List<string> { "A", "B", "C" },
				new List<string> { "D", "E", "F" },
				new List<string> { "G", "H", "I" }
			};

			List<List<string>>? result = GridMap.GridMap.CSVToMap(csvData);

			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void CustomDelimiterReturnsCorrectGrid()
		{
			string csvData = "A;B;C\nD;E;F\nG;H;I";
			string delimiter = ";";
			List<List<string>> expected = new List<List<string>> {
				new List<string> { "A", "B", "C" },
				new List<string> { "D", "E", "F" },
				new List<string> { "G", "H", "I" }
			};

			List<List<string>>? result = GridMap.GridMap.CSVToMap(csvData, delimiter);

			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void QuotedFieldsReturnsCorrectGrid()
		{
			string csvData = "\"Name\",\"Age\",\"Location\"\n\"John Doe\",\"29\",\"New York, NY\"\n\"Jane Smith\",\"25\",\"Los Angeles, CA\"";
			List<List<string>> expected = new List<List<string>> {
				new List<string> { "Name", "Age", "Location" },
				new List<string> { "John Doe", "29", "New York, NY" },
				new List<string> { "Jane Smith", "25", "Los Angeles, CA" }
			};

			List<List<string>>? result = GridMap.GridMap.CSVToMap(csvData);

			CollectionAssert.AreEqual(expected, result);
		}

		[Test]
		public void EmptyInput()
		{
			List<List<string>>? result = GridMap.GridMap.CSVToMap("");

			CollectionAssert.AreEqual(null, result);
		}

	}
}