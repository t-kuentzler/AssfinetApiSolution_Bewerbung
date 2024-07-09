using Assfinet.Shared.Logger;
using Serilog;

namespace Assfinet.DailyUpdate;

class Program
{
    static void Main(string[] args)
    {
        InitializeLogger();
        Log.Information("Täglicher Datenimport gestartet.");
    }
    
    private static void InitializeLogger()
    {
        LoggerConfigurator.ConfigureLogger();
    }
}