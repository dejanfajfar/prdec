using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.IO;

namespace Prdec.Cli;

public class PrdecCommandHandler : ICommandHandler
{
	public Argument<DirectoryInfo?> SolutionsLocation { get; } = new(
		name: "solutionsLocation",
		getDefaultValue: () => null,
		description: "Relative path to the ");

	public Argument<FileInfo?> ProjectLocation { get; } = new(
		name: "projectFileLocation",
		getDefaultValue: () => null,
		description: "Relative path to the project file to analyse");

    public int Invoke(InvocationContext context)
    {
        throw new NotImplementedException();
    }

    public async Task<int> InvokeAsync(InvocationContext context)
    {
	    var projectLocation = context.ParseResult.GetValueForArgument(ProjectLocation);
	    var solutionsLocation = context.ParseResult.GetValueForArgument(SolutionsLocation);

	    var disassembler = new ProjectDisassembler();

	    await disassembler.GetInfo(projectLocation);

        context.Console.Out.WriteLine("Working");
        return 0;
    }
}