using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using AutoMapper;
using FluentValidation;

namespace Assfinet.Shared.Services
{
    public class SparteService : ISparteService
    {
        private readonly ISparteParserService _sparteParserService;
        private readonly IAppLogger _logger;
        private readonly ISparteProcessingService _sparteProcessingService;
        private readonly IMapper _mapper;

        public SparteService(
            ISparteParserService sparteParserService,
            IAppLogger logger,
            ISparteProcessingService sparteProcessingService,
            IMapper mapper)
        {
            _sparteParserService = sparteParserService;
            _logger = logger;
            _sparteProcessingService = sparteProcessingService;
            _mapper = mapper;
        }

        public async Task ImportSpartenDatenAsync(List<object> spartenModels)
        {
            if (spartenModels.Count == 0)
            {
                _logger.LogWarning("Es wurden 0 Spartendaten von der API abgerufen.");
                return;
            }

            _logger.LogInformation($"Es wurden {spartenModels.Count} Spartendaten von der API abgerufen.");

            foreach (var sparteModel in spartenModels)
            {
                try
                {
                    var sparte = (Sparte)_sparteParserService.ParseSparteModel(sparteModel);
                    // Validierung und Speicherung der Sparte-Entity
                    await _sparteProcessingService.ValidateSparteAsync(sparte);
                    await _sparteProcessingService.ProcessImportSparteAsync(sparte);
                }
                catch (ArgumentNullException ex)
                {
                    _logger.LogError($"ArgumentNullException beim Importieren von den Spartendaten mit dem Key '{(sparteModel as dynamic).Key}': {ex.Message}", ex);
                    throw;
                }
                catch (InvalidOperationException ex)
                {
                    _logger.LogError($"InvalidOperationException beim Importieren von den Spartendaten mit dem Key '{(sparteModel as dynamic).Key}': {ex.Message}", ex);
                    throw;
                }
                catch (ValidationException ex)
                {
                    _logger.LogError($"Validierungsfehler bei Spartendaten mit dem Key '{(sparteModel as dynamic).Key}': {ex.Message}", ex);
                    throw;
                }
                catch (UnknownSparteException ex)
                {
                    _logger.LogError($"UnknownSparteException beim Importieren von den Spartendaten mit dem Key '{(sparteModel as dynamic).Key}': {ex.Message}", ex);
                    throw;
                }
                catch (RepositoryException ex)
                {
                    _logger.LogError($"Repository-Fehler beim Import von Spartendaten mit dem Key '{(sparteModel as dynamic).Key}'.", ex);
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Unerwarteter Fehler beim Import von Spartendaten mit dem Key '{(sparteModel as dynamic).Key}'.", ex);
                    throw new SparteServiceException();
                }
            }
        }
    }
}
