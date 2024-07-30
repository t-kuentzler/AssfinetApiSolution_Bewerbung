using Assfinet.Shared.Contracts;
using Serilog;

namespace Assfinet.Shared.Logger
{
    public class AppLogger : IAppLogger
    {
        private readonly ILogger _logger;

        public AppLogger()
        {
            _logger = Log.Logger;
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.Information(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.Warning(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            if (args.Length > 0 && args[0] is Exception exception)
            {
                _logger.Error(exception, message);
            }
            else
            {
                _logger.Error(message, args);
            }
        }
    }
}