using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;

namespace Assfinet.Shared.Repositories
{
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
                throw new UnknownSparteException($"Die Sparte '{sparte.GetType().FullName}' ist unbekannt.");
            }

            try
            {
                await repository.AddAsync((dynamic)sparte);
            }
            catch (RepositoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Ein unerwarteter Fehler ist beim Hinzufügen von '{sparte.GetType().Name}' aufgetreten.", ex);
            }
        }

        public async Task<object?> GetSparteByAmsIdAsync(Guid amsId, Type sparteType)
        {
            var repositoryType = typeof(IGenericSparteRepository<>).MakeGenericType(sparteType);
            dynamic? repository = _serviceProvider.GetService(repositoryType);

            if (repository == null)
            {
                _logger.LogError($"Unbekannter Repository-Typ '{sparteType.FullName}'.");
                throw new UnknownSparteException("Unbekannte Sparte");
            }

            try
            {
                return await repository.GetSparteByAmsIdAsync(amsId);
            }
            catch (RepositoryException ex)
            {
                _logger.LogError($"Ein Fehler ist beim Abrufen von {sparteType.Name} mit AmsId: '{amsId}' aufgetreten: {ex.Message}", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ein unerwarteter Fehler ist beim Abrufen von {sparteType.Name} mit AmsId: '{amsId}' aufgetreten.", ex);
                throw new RepositoryException($"Ein unerwarteter Fehler ist beim Abrufen von {sparteType.Name} mit AmsId: '{amsId}' aufgetreten.", ex);
            }
        }
    }
}
