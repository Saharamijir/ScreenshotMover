using System;
using System.IO;
using System.Runtime.InteropServices;
using Fclp;
using Microsoft.Extensions.DependencyInjection;
using MoverConsole.Config;
using MoverConsole.Core;
using MoverLib.Core;

namespace MoverConsole
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (ConsoleWillBeDestroyedAtTheEnd())
            {
                return HandleNotRunInConsole();
            }
            var (settings, parserResult) = args.ConfigureCommandLineParser();
            return (parserResult.GetCustomResult()) switch
            {
                FluentCommandLineParsingResult.Failure => HandleError(parserResult),
                FluentCommandLineParsingResult.Help => HandleHelp(),
                FluentCommandLineParsingResult.Success => HandleSuccess(settings.Object),
                _ => HandleUnexpectedError()
            };
        }

        private static int HandleNotRunInConsole()
        {
            Console.Error.WriteLine("Please run this application from within command line or powershell");
            Console.ReadKey();
            return 2;
        }
        private static int HandleUnexpectedError()
        {
            Console.Error.WriteLine("Unexpected Error Occured");
            return 3;
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
                .GetRequiredService<IServiceRunner>()
                .Run();
            return result.IsError ? 1 : 0;
        }
        private static bool ConsoleWillBeDestroyedAtTheEnd()
        {
            var processList = new uint[1];
            var processCount = GetConsoleProcessList(processList, 1);

            return processCount == 1;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint GetConsoleProcessList(uint[] processList, uint processCount);
    }
}
