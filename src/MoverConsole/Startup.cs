using MoverLib.Config;
using System;
using Microsoft.Extensions.DependencyInjection;
using Fclp;
using MoverLib.Core;

namespace MoverConsole
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services, string[] args)
        {
            services.AddSingleton<IApplicationSettings>(s => ConfigureCommandLineParser(args).Object);
            services.AddTransient<IFileProvider, FileProvider>();
            services.AddTransient<IScreenshotMovingService, ScreenshotMovingService>();
        }

        private static FluentCommandLineParser<ApplicationSettings> ConfigureCommandLineParser(string[] args)
        {
            var parser = new FluentCommandLineParser<ApplicationSettings>();
            parser.Setup(arg => arg.InputPath)
                .As('i', "InputPath")
                .Required();
            parser.Setup(arg => arg.OutputPath)
                .As('o', "OutputPath");
            parser.Setup(arg => arg.IsRelativePath)
                .As('r', "RelativePath")
                .SetDefault(true);
            var result = parser.Parse(args);
            if (result.HasErrors)
            {
                throw new ArgumentException(result.ErrorText);
            }
            return parser;
        }
    }
}