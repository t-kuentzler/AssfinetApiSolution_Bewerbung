using Assfinet.Shared.Contracts;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Assfinet.Shared.Services
{
    public class SparteProcessingService : ISparteProcessingService
    {
        private readonly IVertragRepository _vertragRepository;
        private readonly IAppLogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public SparteProcessingService(IVertragRepository vertragRepository, IAppLogger logger, IServiceProvider serviceProvider)
        {
            _vertragRepository = vertragRepository;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task ValidateAsync<T>(T sparte) where T : class, IVertragKeyProvider
        {
            var validator = GetValidator<T>();
            await validator.ValidateAndThrowAsync(sparte);
        }

        public async Task ProcessImportSparteAsync<T>(T sparte) where T : class, IVertragKeyProvider
        {
            var repository = GetRepository<T>();

            var existingVertrag = await _vertragRepository.GetVertragByAmsidnrAsync(sparte.Key);
            if (existingVertrag == null)
            {
                _logger.LogError($"Der Vertrag mit dem Key '{sparte.Key}' konnte nicht in der Datenbank gefunden werden.");
                return;
            }

            var existingSparte = await repository.GetSparteByAmsidnrAsync(sparte.Key);
            if (existingSparte != null)
            {
                _logger.LogError($"Der Spartendatensatz mit dem Key '{sparte.Key}' existiert bereits.");
                return;
            }

            _logger.LogInformation($"Es wird versucht, die Sparte mit dem Key '{sparte.Key}' in der Datenbank zu erstellen.");
            await repository.AddSparteAsync(sparte);
            _logger.LogInformation($"Die Sparte mit dem Key '{sparte.Key}' wurde erfolgreich in der Datenbank erstellt.");
        }

        private IValidatorWrapper<T> GetValidator<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<IValidatorWrapper<T>>();
        }

        private ISparteRepository<T> GetRepository<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<ISparteRepository<T>>();
        }
    }
}
