using System.Reflection.Metadata.Ecma335;
using Prdec.ValueObjects;

namespace Prdec.ProjectParser;

public class NullParser : IProjectParser
{
	public bool CanParse(string? projectFilePath)
	{
		return true;
	}

	public Task<Project> ParseAsync(string? projectFilePath)
	{
		return Task.FromResult(Project.NullProject);
	}
}