using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Models;
using FluentValidation;

namespace Assfinet.Shared.Services;

public class SparteService : ISparteService
{
    private readonly ISparteParserService _sparteParserService;
    private readonly IAppLogger _logger;
    private readonly ISparteProcessingService _sparteProcessingService;

    public SparteService(ISparteParserService sparteParserService, IAppLogger logger,
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

        _logger.LogInformation($"Es wurden {spartenModels.Count} Verträge von der API abgerufen.");

        foreach (var spartenModel in spartenModels)
        {
            try
            {
                var sparte = _sparteParserService.ParseModelToDbEntity((VertragSparteModel)spartenModel);
                await _sparteProcessingService.ValidateAsync(sparte);
                await _sparteProcessingService.ProcessImportAsync(sparte);
            }
            catch (ValidationException ex)
            {
                _logger.LogError(
                    $"Bei dem Vertrag mit der AmsId '{((VertragSparteModel)spartenModel).Id}' ist ein Validierungsfehler aufgetreten: {ex.Message}",
                    ex);
                throw;
            }
            catch (RepositoryException ex)
            {
                _logger.LogError(
                    $"Repository-Exception beim Importieren von dem Vertrag mit der AmsId '{((VertragSparteModel)spartenModel).Id}'.",
                    ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"Es ist ein unerwarteter Fehler beim Importieren von dem Vertrag mit der AmsId '{((VertragSparteModel)spartenModel).Id}' aufgetreten.",
                    ex);
                throw new SparteServiceException();
            }
        }
    }


}