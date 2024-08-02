using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Models;
using AutoMapper;

namespace Assfinet.Shared.Services;

public class SparteParserService : ISparteParserService
{
    private readonly IMapper _mapper;
    private readonly IAppLogger _logger;

    public SparteParserService(IMapper mapper, IAppLogger logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public KrvSparte ParseSparteModelToKrvSparte(KrvModel krvModel)
    {
        try
        {
            if (krvModel == null)
            {
                throw new ArgumentNullException(nameof(krvModel));
            }

            var krvSparte = _mapper.Map<KrvSparte>(krvModel);
            if (krvSparte == null)
            {
                throw new InvalidOperationException("Mapping von SparteModel zu KrvSparte fehlgeschlagen.");
            }

            return krvSparte;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Es ist ein unerwarteter Fehler beim Parsen von SparteModel zu KrvSparte aufgetreten.",
                ex);
            throw new SparteParserServiceException();
        }
    }
}