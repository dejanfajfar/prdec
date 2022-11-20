using System.CommandLine;
using System.CommandLine.Invocation;

namespace Prdec.Cli
{
    public class CliCommands
    {
        public Command GetRootCommand()
        {
            var rootCommandHandler = new PrdecCommandHandler();
            var rootCommand = new RootCommand("Recursively repairs the project dependencies");
            rootCommand.AddArgument(rootCommandHandler.ProjectLocation);
            rootCommand.AddArgument(rootCommandHandler.SolutionsLocation);

            rootCommand.Handler = rootCommandHandler;

            return rootCommand;
        }
    }
}
