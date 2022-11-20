using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using Prdec.ValueObjects;

namespace Prdec.ProjectParser;

public class NewProjectFileFormatParser : BaseProjectParser
{
	public const string RootNodeName = "Project";
	public const string ItemGroupNodeName = "ItemGroup";
	public const string PackageReferenceNodeName = "PackageReference";
	public const string ProjectReferenceNodeName = "ProjectReference";
	public const string IncludeAttributeName = "Include";
	public const string VersionAttributeValue = "Version";
	
    protected override async Task<Project> ParseProjectFileAsync(string path)
    {
	    var fileInfo = new FileInfo(path);
	    if (fileInfo.Exists is false)
	    {
		    return Project.NullProject;
	    }
		
		await using var fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
		var rootElement = await XElement.LoadAsync(fileStream, LoadOptions.None, CancellationToken.None);

		var packageReferences = from itemGroup in rootElement.Descendants(ItemGroupNodeName)
			from referenceItem in itemGroup.Descendants(PackageReferenceNodeName)
			select FromPackageDependency(referenceItem);

		var projectReferences = from itemGroup in rootElement.Descendants(ItemGroupNodeName)
			from referenceItem in itemGroup.Descendants(ProjectReferenceNodeName)
			select FromProjectDependency(referenceItem);

		return new Project(Path.GetFileNameWithoutExtension(fileInfo.Name), fileInfo.FullName)
		{
			Dependencies = packageReferences.Union(projectReferences).ToList()
		};
	}

	protected override bool IsKnownProjectFileType(string path)
	{
		return true;
	}

	private ProjectDependency FromPackageDependency(XElement element)
	{
		return new ProjectDependency(element.Attribute("Include").Value, DependencyType.Package);
	}

	private ProjectDependency FromProjectDependency(XElement element)
	{
		return new ProjectDependency(element.Attribute("Include").Value, DependencyType.Project);
    }
}