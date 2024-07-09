using Serilog;

namespace Assfinet.Shared.Logger
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