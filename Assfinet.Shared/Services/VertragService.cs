using Assfinet.Shared.Contracts;

namespace Assfinet.Shared.Services;

public class VertragService : IVertragService
{
    private readonly IVertragParserService _vertragParserService;
    private readonly IAppLogger _logger;
    private readonly IVertragProcessingService _kundeProcessingService;

    public VertragService(IVertragParserService vertragParserService, IAppLogger logger,
        IVertragProcessingService kundeProcessingService)
    {
        _vertragParserService = vertragParserService;
        _logger = logger;
        _kundeProcessingService = kundeProcessingService;
    }
}