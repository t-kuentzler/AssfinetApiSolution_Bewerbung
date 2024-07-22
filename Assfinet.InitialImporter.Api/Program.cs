using Assfinet.Shared.Contracts;
using Assfinet.Shared.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Assfinet.InitialImporter.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            
            // Configure Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            // Load shared configurations
            var sharedConfigPath = GetSharedAppSettingsPath();
            
            builder.Configuration
                .AddJsonFile(sharedConfigPath, optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            // Add Shared Services and configurations
            builder.Services.AddSharedServices(builder.Configuration);
            builder.Services.AddSerilogLogging();
            builder.Services.AddApiSettings(builder.Configuration);

            // Add Controllers services
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            var app = builder.Build();

            var logger = app.Services.GetRequiredService<IAppLogger>();
            logger.LogInformation("API-Anwendung gestartet.");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
        
        private static string GetSharedAppSettingsPath()
        {
            //appsettings.json liegt direkt im Veröffentlichungsverzeichnis
            var baseDirectory = AppContext.BaseDirectory;
            var sharedConfigPath = Path.Combine(baseDirectory, "appsettings.json");

            if (!File.Exists(sharedConfigPath))
            {
                throw new FileNotFoundException($"The configuration file '{sharedConfigPath}' was not found and is not optional.");
            }

            return sharedConfigPath;
        }
    }
    
    
}