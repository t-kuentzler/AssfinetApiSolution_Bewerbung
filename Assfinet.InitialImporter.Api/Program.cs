using Assfinet.Shared;
using Assfinet.Shared.Contracts;
using Assfinet.Shared.DependencyInjection;
using Assfinet.Shared.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Assfinet.InitialImporter.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            
            // Configure Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                options.UseInlineDefinitionsForEnums();
                options.MapType<Spartentypen>(() => new OpenApiSchema
                {
                    Type = "string",
                    Enum = Enum.GetNames(typeof(Spartentypen)).Select(name => new OpenApiString(name) as IOpenApiAny).ToList()
                });
            });
            
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

            await CheckDatabaseConnection(app);

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
        
        private static async Task CheckDatabaseConnection(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbContext = services.GetRequiredService<ApplicationDbContext>();
                    var canConnect = await dbContext.Database.CanConnectAsync();
                    if (canConnect)
                    {
                        Log.Information("Verbindung zur Datenbank erfolgreich.");
                    }
                    else
                    {
                        Log.Error("Fehler bei der Verbindung zur Datenbank.");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Ein unerwarteter Fehler ist aufgetreten beim Versuch, die Datenbankverbindung zu prüfen.");
                }
            }
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