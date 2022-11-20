using Prdec.ProjectParser;

namespace Prdec.Tests.ProjectParsers;

[TestClass]
public class ProjectParserRegistryTests
{
	[TestMethod]
	public void GetParserFor_GivenNull_ThenNullParserReturned()
	{
		var parser = ProjectParserRegistry.GetParserFor(null);

		Assert.IsInstanceOfType(parser, typeof(NullParser));
	}

	[TestMethod]
	public void GetParserFor_GivenNonExisting_ThenNullParserReturned()
	{

	}
}