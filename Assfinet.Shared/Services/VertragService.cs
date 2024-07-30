using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Models;
using FluentValidation;

namespace Assfinet.Shared.Services;

public class VertragService : IVertragService
{
    private readonly IVertragParserService _vertragParserService;
    private readonly IAppLogger _logger;
    private readonly IVertragProcessingService _vertragProcessingService;

    public VertragService(IVertragParserService vertragParserService, IAppLogger logger,
        IVertragProcessingService vertragProcessingService)
    {
        _vertragParserService = vertragParserService;
        _logger = logger;
        _vertragProcessingService = vertragProcessingService;
    }
    
    public async Task ImportVertraegeAsync(List<VertragModel> vertraegeModels)
    {
        if (vertraegeModels.Count == 0)
        {
            _logger.LogWarning("Es wurden 0 Verträge von der API abgerufen.");
            return;
        }

        _logger.LogInformation($"Es wurden {vertraegeModels.Count} Kunden von der API abgerufen.");

        foreach (var vertragModel in vertraegeModels)
        {

            try
            {
                var vertrag = _vertragParserService.ParseKundeModelToDbEntity(vertragModel);
                await _vertragProcessingService.ValidateKundeAsync(vertrag);
                await _vertragProcessingService.ProcessImportKundeAsync(vertrag);
            }
            catch (ValidationException ex)
            {
                _logger.LogError(
                    $"Bei dem Vertrag mit der AmsId '{vertragModel.Id}' ist ein Validierungsfehler aufgetreten: {ex.Message}",
                    ex);
                throw;
            }
            catch (RepositoryException ex)
            {
                _logger.LogError(
                    $"Repository-Exception beim Importieren von dem Vertrag mit der AmsId '{vertragModel.Id}'.", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"Es ist ein unerwarteter Fehler beim Importieren von dem Vertrag mit der AmsId '{vertragModel.Id}' aufgetreten.",
                    ex);
                throw new VertragServiceException();
            }
        }
}