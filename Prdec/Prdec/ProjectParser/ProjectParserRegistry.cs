namespace Prdec.ProjectParser;

public class ProjectParserRegistry
{
	protected ProjectParserRegistry()
	{
		Parsers = new List<IProjectParser>();
	}

	private IList<IProjectParser> Parsers { get; }

	private static ProjectParserRegistry Instance => new();

	public static IProjectParser GetParserFor(string? projectFilePath)
	{
		return Instance.Parsers.FirstOrDefault(p => p.CanParse(projectFilePath)) ?? new NullParser();
	}
}