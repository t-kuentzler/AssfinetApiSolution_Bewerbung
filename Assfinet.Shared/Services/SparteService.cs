using Assfinet.Shared.Contracts;
using Assfinet.Shared.Enums;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Models;
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
            _logger.LogWarning("Es wurden 0 Sparten-Daten von der API abgerufen.");
            return;
        }

        _logger.LogInformation($"Es wurden {spartenModels.Count} Sparten-Daten von der API abgerufen.");

        foreach (var sparteModel in spartenModels)
        {
            try
            {
                var parsedSparte = _sparteParserService.ParseSparteModel(sparteModel);
                await _sparteProcessingService.ValidateAndProcessSparteAsync(parsedSparte);
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Validierungsfehler bei Sparte mit dem Schlüssel '{(sparteModel as dynamic).Key}': {ex.Message}", ex);
                throw;
            }
            catch (RepositoryException ex)
            {
                _logger.LogError($"Repository-Fehler beim Import von Sparte mit dem Schlüssel '{(sparteModel as dynamic).Key}': {ex.Message}", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unerwarteter Fehler beim Import von Sparte mit dem Schlüssel '{(sparteModel as dynamic).Key}': {ex.Message}", ex);
                throw new SparteServiceException();
            }
        }
    }
}