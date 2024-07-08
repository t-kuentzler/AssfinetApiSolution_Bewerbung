using Serilog;
using System.IO;

namespace Assfinet.Shared.Logging
{
    public static class LoggerConfigurator
    {
        public static void ConfigureLogger()
        {
            var logFilePath = Path.Combine("logs", "log.txt");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console() 
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)  
                .CreateLogger();
        }
    }
}