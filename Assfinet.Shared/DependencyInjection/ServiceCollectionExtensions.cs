using Assfinet.Shared.Configurations;
using Assfinet.Shared.Contracts;
using Assfinet.Shared.Logger;
using Assfinet.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Assfinet.Shared.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAppLogger, AppLogger>();
            services.AddHttpClient<IApiService, ApiService>(); 
            services.AddSingleton(configuration);

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

        public static IServiceCollection AddApiSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var assfinetApiSettings = new AssfinetApiSettings();
            configuration.GetSection("ApiSettings").Bind(assfinetApiSettings);

            // Override with environment variables if available
            assfinetApiSettings.Password = Environment.GetEnvironmentVariable("HANSMANN_ASSFINET_USER_PASSWORD") ?? assfinetApiSettings.Password;
            assfinetApiSettings.ClientSecret = Environment.GetEnvironmentVariable("HANSMANN_ASSFINET_CLIENTSECRET") ?? assfinetApiSettings.ClientSecret;

            services.Configure<AssfinetApiSettings>(options =>
            {
                options.License = assfinetApiSettings.License;
                options.BaseUriApi = assfinetApiSettings.BaseUriApi;
                options.BaseUriAuth = assfinetApiSettings.BaseUriAuth;
                options.UserName = assfinetApiSettings.UserName;
                options.Password = assfinetApiSettings.Password;
                options.ClientId = assfinetApiSettings.ClientId;
                options.ClientSecret = assfinetApiSettings.ClientSecret;
            });

            return services;
        }
    }
}