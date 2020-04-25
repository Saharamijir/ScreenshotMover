using Microsoft.Extensions.DependencyInjection;

namespace MoverLib.Config
{
    public static class RegisterIoC
    {
        public static void RegisterMoverLib(this IServiceCollection services, IMoverLibSettings settings)
        {
            services.AddSingleton(settings);
        }
    }
}