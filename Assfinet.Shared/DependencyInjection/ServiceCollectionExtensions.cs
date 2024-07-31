using Assfinet.Shared.Configurations;
using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Logger;
using Assfinet.Shared.Repositories;
using Assfinet.Shared.Services;
using Assfinet.Shared.Validators;
using Azure.Core;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
            var connectionString = Environment.GetEnvironmentVariable("HANSMANN_ASSFINET_SCHATTENDATENBANK_CONNECTIONSTRING_TEST");

            if (!string.IsNullOrEmpty(connectionString))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23)))); // Version hier anpassen
            }
            else
            {
                throw new InvalidOperationException(
                    "Die Verbindungszeichenfolge wurde nicht in der Umgebungsvariablen gefunden.");
            }
            
            //Services
            services.AddHttpClient<IApiService, ApiService>();
            services.AddScoped<IKundeService, KundeService>();
            services.AddScoped<IKundeParserService, KundeParserService>();
            services.AddScoped<IKundeProcessingService, KundeProcessingService>();
            services.AddScoped<IVertragService, VertragService>();
            services.AddScoped<IVertragParserService, VertragParserService>();
            services.AddScoped<IVertragProcessingService, VertragProcessingService>();
            services.AddScoped<ISparteService, SparteService>();
            services.AddScoped<ISparteParserService, SparteParserService>();
            services.AddScoped<ISparteProcessingService, SparteProcessingService>();

            //Repositories
            services.AddScoped<IKundeRepository, KundeRepository>();
            services.AddScoped<IVertragRepository, VertragRepository>();
            services.AddTransient<ISparteRepository<KrvSparte>, KrvSparteRepository>();

            //Automapper
            services.AddAutoMapper(typeof(MappingProfile));
            
            // Validator Wrapper
            services.AddTransient(typeof(IValidatorWrapper<>), typeof(ValidatorWrapper<>));
            
            //Validator
            services.AddTransient<IValidator<Kunde>, KundeValidator>();
            services.AddTransient<IValidator<KundePersonenDetails>, KundePersonenDetailsValidator>();
            services.AddTransient<IValidator<KundeKontakt>, KundeKontaktValidator>();
            services.AddTransient<IValidator<KundeFinanzen>, KundeFinanzenValidator>();
            services.AddTransient<IValidator<Vertrag>, VertragValidator>();
            services.AddTransient<IValidator<VertragDetails>, VertragDetailsValidator>();
            services.AddTransient<IValidator<VertragHistorie>, VertragHistorieValidator>();
            services.AddTransient<IValidator<VertragBank>, VertragBankValidator>();

            
            services.AddTransient<IAppLogger, AppLogger>();
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