using Prdec.ValueObjects;

namespace Prdec.ProjectParser;

public abstract class BaseProjectParser : IProjectParser
{
	public bool CanParse(string? projectFilePath)
	{
		return File.Exists(projectFilePath) && IsKnownProjectFileType(projectFilePath);
	}

	public async Task<Project> ParseAsync(string? projectFilePath)
	{
		if (CanParse(projectFilePath) && projectFilePath is not null)
			return await ParseProjectFileAsync(projectFilePath);
		throw new ProjectParserException(projectFilePath);
	}

	protected abstract Task<Project> ParseProjectFileAsync(string path);

	protected abstract bool IsKnownProjectFileType(string path);
}