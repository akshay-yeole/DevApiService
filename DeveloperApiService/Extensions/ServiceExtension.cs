using Contracts;
using LoggerService;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperApiService.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();
    }
}
