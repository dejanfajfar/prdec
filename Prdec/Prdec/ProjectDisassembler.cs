namespace Prdec;

public class ProjectDisassembler
{
	public ProjectDisassembler()
	{

	}

	public async Task GetInfo(FileInfo? projectFile)
	{
		if (projectFile == null)
		{
			return;
		}

		var fileContent = await projectFile.OpenText().ReadToEndAsync();

		var projectF = new Microsoft.Build.Evaluation.Project(projectFile.FullName);

		Console.WriteLine(projectF.FullPath);
	}
}