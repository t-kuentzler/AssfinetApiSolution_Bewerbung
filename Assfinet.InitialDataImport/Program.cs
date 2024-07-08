using Assfinet.Shared.Logging;
using Serilog;

namespace Assfinet.InitialDataImport;

class Program
{
    static void Main(string[] args)
    {
        InitializeLogger();
        Log.Information("Initialer Datenimport wurde gestartet.");
    }
    
    private static void InitializeLogger()
    {
        LoggerConfigurator.ConfigureLogger("InitialDataImport");
    }
}