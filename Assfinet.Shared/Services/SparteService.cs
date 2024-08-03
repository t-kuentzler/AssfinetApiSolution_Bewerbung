using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;
using FluentValidation;

namespace Assfinet.Shared.Services;

public class SparteService : ISparteService
{
    private readonly ISparteParserService _sparteParserService;
    private readonly IAppLogger _logger;
    private readonly ISparteProcessingService _sparteProcessingService;

    public SparteService(
        ISparteParserService sparteParserService,
        IAppLogger logger,
        ISparteProcessingService sparteProcessingService)
    {
        _sparteParserService = sparteParserService;
        _logger = logger;
        _sparteProcessingService = sparteProcessingService;
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
                //Model zu Entity parsen
                var parsedSparte = _sparteParserService.ParseSparteModel(sparteModel);
                //Entity validieren
                await _sparteProcessingService.ValidateSparteAsync(parsedSparte);
                //In Db erstellen
                await _sparteProcessingService.ProcessImportSparteAsync(parsedSparte);
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Validierungsfehler bei Spartendaten mit dem Schlüssel '{(sparteModel as dynamic).Key}': {ex.Message}", ex);
                throw;
            }
            catch (UnknownSparteException ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            catch (RepositoryException ex)
            {
                _logger.LogError($"Repository-Fehler beim Import von Spartendaten mit dem Schlüssel '{(sparteModel as dynamic).Key}'.", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unerwarteter Fehler beim Import von Spartendaten mit dem Schlüssel '{(sparteModel as dynamic).Key}'.", ex);
                throw new SparteServiceException();
            }
        }
    }
}