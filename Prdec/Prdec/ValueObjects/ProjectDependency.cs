namespace Prdec.ValueObjects;

public record ProjectDependency(string Name, DependencyType Type)
{
	public string Name { get; set; } = Name;
	public DependencyType DependencyType { get; set; } = Type;
}