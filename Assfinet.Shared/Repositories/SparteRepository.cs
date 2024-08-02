using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Models;

namespace Assfinet.Shared.Repositories;

public class SparteRepository : ISparteRepository
{
    private readonly IGenericSparteRepository<KrvSparte> _krvRepository;
    private readonly IGenericSparteRepository<DepModel> _depRepository;
    private readonly IAppLogger _logger;
    

    public SparteRepository(
        IGenericSparteRepository<KrvSparte> krvRepository,
        IGenericSparteRepository<DepModel> depRepository,
        IAppLogger logger)
    {
        _krvRepository = krvRepository;
        _depRepository = depRepository;
        _logger = logger;
    }

    public async Task AddAsync(object sparte)
    {
        switch (sparte)
        {
            case KrvSparte krvSparte:
                await _krvRepository.AddAsync(krvSparte);
                break;
            // case DepModel depModel:
            //     await _depRepository.AddAsync(depModel);
            //     break;
            default:
                _logger.LogWarning($"Unknown type {sparte.GetType().FullName}");
                throw new UnknownSparteException("Unbekannte Sparte");
        }
    }

    public async Task<object?> GetSparteByAmsIdAsync(Guid amsId)
    {
        var krvSparte = await _krvRepository.GetSparteByAmsIdAsync(amsId);
        if (krvSparte != null)
        {
            return krvSparte;
        }

        // var depModel = await _depRepository.GetSparteByAmsIdAsync(amsId);
        // if (depModel != null)
        // {
        //     return depModel;
        // }

        return null;
    }

}
