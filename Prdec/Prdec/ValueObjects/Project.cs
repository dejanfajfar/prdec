using System.Diagnostics;

namespace Prdec.ValueObjects;

public record Project(string Name, string Path)
{
	public static Project NullProject => new("NullProject", string.Empty);

	public string Name { get; set; } = Name;
	public string Path { get; set; } = Path;
	public IList<ProjectDependency> Dependencies { get; set; } = new List<ProjectDependency>();
}