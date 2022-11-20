using Prdec.ValueObjects;

namespace Prdec.ProjectParser;

public interface IProjectParser
{
	public bool CanParse(string? projectFilePath);

	public Task<Project> ParseAsync(string? projectFilePath);
}