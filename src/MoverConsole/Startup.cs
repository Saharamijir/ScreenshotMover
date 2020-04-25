using System;
 using Microsoft.Extensions.DependencyInjection;
 using Fclp;
 using MoverConsole.Config;
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
         }
 
         private static void RegisterSettings(this IServiceCollection services, ApplicationSettings settings)
         {
             services.AddSingleton<IApplicationSettings>(s => settings);
             services.RegisterMoverLib(settings);
         }
     }
 }