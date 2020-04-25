using System;
using Fclp;
using Microsoft.Extensions.DependencyInjection;
using MoverConsole.Config;
using MoverLib.Core;

namespace MoverConsole
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var (settings, parserResult) = args.ConfigureCommandLineParser();
            return (parserResult.CustomResult()) switch
            {
                FluentCommandLineParsingResult.Failure => HandleError(parserResult),
                FluentCommandLineParsingResult.Help => HandleHelp(),
                FluentCommandLineParsingResult.Success => HandleSuccess(settings.Object),
                _ => HandleUnexpectedError()
            };
        }

        private static int HandleUnexpectedError()
        {
            Console.Error.WriteLine("Unexpected Error Occured");
            return 2;
        }
        
        private static int HandleError(ICommandLineParserResult parserResult)
        {
            Console.Error.WriteLine(parserResult.ErrorText);
            return 1;
        }

        private static int HandleHelp()
        {
            return 0;
        }

        private static int HandleSuccess(ApplicationSettings settings)
        {
            var services = new ServiceCollection();
            services.ConfigureServices(settings);
            var servicesProvider = services.BuildServiceProvider();
            var result = servicesProvider
                .GetService<IScreenshotMovingService>()
                .MoveScreenshotsToSeriesDirectories(
                    servicesProvider
                        .GetService<IFileProvider>()
                        .GetScreenshotFiles()
                );
            return result.IsError ? 1 : 0;
        }
    }
}
