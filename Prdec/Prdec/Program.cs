using System.CommandLine;
using Prdec.Cli;
using Spectre.Console;

AnsiConsole.Write(new FigletText("PRDEC").Color(Color.RosyBrown));

await new CliCommands().GetRootCommand().InvokeAsync(args);

Console.ReadLine();