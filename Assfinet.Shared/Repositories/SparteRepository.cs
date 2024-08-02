using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;

namespace Assfinet.Shared.Repositories;

public class SparteRepository : ISparteRepository
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IAppLogger _logger;

    public SparteRepository(IServiceProvider serviceProvider, IAppLogger logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task AddAsync(object sparte)
    {
        var repositoryType = typeof(IGenericSparteRepository<>).MakeGenericType(sparte.GetType());
        dynamic? repository = _serviceProvider.GetService(repositoryType);

        if (repository == null)
        {
            _logger.LogWarning($"Unbekannter Repository Typ '{sparte.GetType().FullName}'");
            throw new UnknownSparteException("Unbekannte Sparte");
        }

        await repository.AddAsync((dynamic)sparte);
    }

    public async Task<object?> GetSparteByAmsIdAsync(Guid amsId, Type sparteType)
    {
        var repositoryType = typeof(IGenericSparteRepository<>).MakeGenericType(sparteType);
        dynamic? repository = _serviceProvider.GetService(repositoryType);

        if (repository == null)
        {
            _logger.LogWarning($"Unbekannter Repository Typ '{sparteType.FullName}'.");
            throw new UnknownSparteException("Unbekannte Sparte");
        }

        return await repository.GetSparteByAmsIdAsync(amsId);
    }

}


