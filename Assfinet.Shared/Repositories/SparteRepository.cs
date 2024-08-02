using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Models;

public class SparteRepository : ISparteRepository
{
    private readonly IGenericSparteRepository<KrvSparte> _krvRepository;
    private readonly IGenericSparteRepository<DepModel> _depRepository;
    private readonly IVertragRepository _vertragRepository;
    private readonly ISparteParserService _sparteParserService;
    private readonly IAppLogger _logger;
    

    public SparteRepository(
        IGenericSparteRepository<KrvSparte> krvRepository,
        IGenericSparteRepository<DepModel> depRepository,
        IVertragRepository vertragRepository,
        ISparteParserService sparteParserService,
        IAppLogger logger)
    {
        _krvRepository = krvRepository;
        _depRepository = depRepository;
        _vertragRepository = vertragRepository;
        _sparteParserService = sparteParserService;
        _logger = logger;
    }

    public async Task SaveSpartenDatenAsync<T>(List<T> spartenDaten) where T : class
    {
        foreach (var item in spartenDaten)
        {
            if (item is KrvModel sparteModel)
            {
                var krvSparte = _sparteParserService.ParseSparteModelToKrvSparte(sparteModel);
                var key = krvSparte.Key;
                var vertrag = await _vertragRepository.GetVertragByAmsidnrAsync(key);
                if (vertrag == null)
                {
                    _logger.LogWarning($"No matching Vertrag found for key {key}");
                    return;
                }
                
                
                await _krvRepository.AddAsync(krvSparte);

            }
            // else if (item is DepModel depModel)
            // {
            //     var key = depModel.Key;
            //     var vertrag = await _vertragRepository.GetVertragByAmsidnrAsync(key);
            //     if (vertrag != null)
            //     {
            //         await _depRepository.AddAsync(depModel);
            //     }
            //     else
            //     {
            //         _logger.LogWarning($"No matching Vertrag found for key {key}");
            //     }
            // }
            else
            {
                _logger.LogWarning($"Unknown type {item.GetType().FullName}");
                throw new UnknownSparteException("Unbekannte Sparte");
            }
        }
    }
}
