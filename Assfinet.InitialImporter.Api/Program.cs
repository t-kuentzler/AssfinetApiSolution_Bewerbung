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

            // Swagger/OpenAPI konfigurieren
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Fügen Sie die Shared Services hinzu
            builder.Services.AddSharedServices();
            builder.Services.AddSerilogLogging();
            
            // Fügen Sie die Controller-Dienste hinzu
            builder.Services.AddControllers();

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
    }
}