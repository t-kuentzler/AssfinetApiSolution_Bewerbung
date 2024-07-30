using Assfinet.Shared.Contracts;

namespace Assfinet.Shared.Services;

public class SparteService : ISparteService
{
    private readonly ISparteParserService _sparteParserService;
    private readonly IAppLogger _logger;
    private readonly ISparteProcessingService _sparteProcessingService;

    public SparteService(ISparteParserService sparteParserService, IAppLogger logger,
        ISparteProcessingService sparteProcessingService)
    {
        _sparteParserService = sparteParserService;
        _logger = logger;
        _sparteProcessingService = sparteProcessingService;
    }
}