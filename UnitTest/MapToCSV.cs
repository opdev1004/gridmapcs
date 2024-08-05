namespace UnitTest
{
	public class MapToCSV
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void BasicGridReturnsCorrectCSV()
		{
			var grid = new List<List<string>>
			{
				new List<string> { "Name", "Age", "Location" },
				new List<string> { "John Doe", "29", "New York, NY" },
				new List<string> { "Jane Smith", "25", "Los Angeles, CA" }
			};
			string expected = "Name,Age,Location\nJohn Doe,29,\"New York, NY\"\nJane Smith,25,\"Los Angeles, CA\"\n";

			string result = GridMap.GridMap.MapToCSV(grid);

			Assert.That(result, Is.EqualTo(expected));
		}
	}
}