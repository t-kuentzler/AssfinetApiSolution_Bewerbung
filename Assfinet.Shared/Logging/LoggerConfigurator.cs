using Serilog;
using System.IO;

namespace Assfinet.Shared.Logging
{
    public static class LoggerConfigurator
    {
        public static void ConfigureLogger(string applicationName)
        {
            var logFilePath = Path.Combine("logs", $"{applicationName}-log.txt");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console() 
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)  
                .CreateLogger();
        }
    }
}