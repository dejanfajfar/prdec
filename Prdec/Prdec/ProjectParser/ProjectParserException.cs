namespace Prdec.ProjectParser;

public class ProjectParserException : Exception
{
	private readonly string? _projectFilePath;

	public ProjectParserException(string? projectFilePath) :
		base($"Error parsing project {projectFilePath}")
	{
		_projectFilePath = projectFilePath;
	}
}