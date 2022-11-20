using Prdec.ProjectParser;

namespace Prdec.Tests.ProjectParsers;

[TestClass]
public class ProjectFileParsersTests
{
	private IProjectParser _parser;

	[TestInitialize]
	public void SetUp()
	{
		_parser = new NewProjectFileFormatParser();
	}

	[TestMethod]
	[DeploymentItem(@".\Prdec.Tests\ProjectParsers\SampleProject.xml")]
	public async Task Given_ValidProjectfile_Then_NameCorrect()
	{
		var res = await _parser.ParseAsync("SampleProject.xml");

		Assert.IsNotNull(res);
		Assert.AreEqual("SampleProject", res.Name);
	}
}