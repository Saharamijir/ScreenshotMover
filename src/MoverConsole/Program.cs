using System;
using Fclp.Internals.Extensions;
using Microsoft.Extensions.DependencyInjection;
using MoverLib.Core;

namespace MoverConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            new Startup().ConfigureServices(services, args);
            var servicesProvider = services.BuildServiceProvider();
            servicesProvider
                .GetService<IScreenshotMovingService>()
                .MoveScreenshotsToSeriesDirectories(
                    servicesProvider
                        .GetService<IFileProvider>()
                        .GetScreenshotFiles()
                );
        }
    }
}
