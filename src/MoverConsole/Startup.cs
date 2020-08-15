using Microsoft.Extensions.DependencyInjection;
using MoverConsole.Config;
using MoverConsole.Core;
using MoverLib.Config;
using MoverLib.Core;

namespace MoverConsole
{
    internal static class Startup
    {
        internal static void ConfigureServices(this IServiceCollection services, ApplicationSettings settings)
        {
            services.RegisterSettings(settings);
            services.AddTransient<IFileProvider, FileProvider>();
            services.AddTransient<IScreenshotMovingService, ScreenshotMovingService>();
            services.AddTransient<IServiceRunner, ServiceRunner>();
        }

        private static void RegisterSettings(this IServiceCollection services, ApplicationSettings settings)
        {
            services.AddSingleton<IApplicationSettings>(s => settings);
            services.RegisterMoverLib(settings);
        }
    }
}