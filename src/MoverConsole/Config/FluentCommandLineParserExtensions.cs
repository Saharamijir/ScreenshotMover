using System;
using Fclp;

namespace MoverConsole.Config
{
    internal static class FluentCommandLineParserExtensions
    {
        public static (FluentCommandLineParser<ApplicationSettings>, ICommandLineParserResult) ConfigureCommandLineParser(this string[] args)
        {

            var parser = new FluentCommandLineParser<ApplicationSettings>();
            parser.SetupHelp("help", "h").WithHeader("HELP").Callback(x => Console.WriteLine(x)).UseForEmptyArgs();
            parser.Setup(arg => arg.InputPath)
                .As('i', "InputPath")
                .WithDescription("Sets path where screenshots will be searched")
                .Required();
            parser.Setup(arg => arg.OutputPath)
                .As('o', "OutputPath")
                .WithDescription("Sets path where sorted folders will be created, if not provided current path is used");
            parser.Setup(arg => arg.IsRelativePath)
                .As('r', "RelativePath")
                .WithDescription("DON'T USE IT NOW! FOR NOW IT'S BROKEN. DEFAULTS TO true")
                .SetDefault(true);
            return (parser, parser.Parse(args));
        }

        public static FluentCommandLineParsingResult GetCustomResult(
            this ICommandLineParserResult parserResult)
        {
            if (parserResult.HelpCalled)
            {
                return FluentCommandLineParsingResult.Help;
            }
            return parserResult.HasErrors ? FluentCommandLineParsingResult.Failure : FluentCommandLineParsingResult.Success;
        }
    }
}