using Assfinet.Shared.Contracts;
using Assfinet.Shared.Logger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Assfinet.Shared.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddTransient<IAppLogger, AppLogger>();
            return services;
        }

        public static IServiceCollection AddSerilogLogging(this IServiceCollection services)
        {
            LoggerConfigurator.ConfigureLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(dispose: true);
            });

            return services;
        }
    }
}