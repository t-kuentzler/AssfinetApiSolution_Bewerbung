using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Models;
using FluentValidation;

namespace Assfinet.Shared.Services;

public class KundeService : IKundeService
{
    private readonly IKundeParserService _kundeParserService;
    private readonly IAppLogger _logger;
    private readonly IKundeProcessingService _kundeProcessingService;

    public KundeService(IKundeParserService kundeParserService,
        IAppLogger logger, IKundeProcessingService kundeProcessingService)
    {
        _kundeParserService = kundeParserService;
        _logger = logger;
        _kundeProcessingService = kundeProcessingService;
    }

    public async Task SaveKundenAsync(List<KundeModel> kundenModels)
    {
        try
        {
            if (kundenModels.Count == 0)
            {
                _logger.LogWarning("Es wurden 0 Kunden von der API abgerufen.");
                return;
            }

            _logger.LogInformation($"Es wurden {kundenModels.Count} Kunden von der API abgerufen.");

            foreach (var kundeModel in kundenModels)
            {
                var kunde = _kundeParserService.ParseKundeModelToDbEntity(kundeModel);

                try
                {
                    await _kundeProcessingService.ValidateKundeAsync(kunde);
                    await _kundeProcessingService.ProcessKundeAsync(kunde);
                }
                catch (ValidationException ex)
                {
                    _logger.LogError(
                        $"Bei dem Kunden mit der AmsId '{kunde.AmsId}' ist ein Validierungsfehler aufgetreten: {ex.Message}",
                        ex);
                }
                catch (RepositoryException ex)
                {
                    _logger.LogError(
                        $"Repository-Exception beim Importieren von dem Kunden mit der AmsId '{kunde.AmsId}'.", ex);
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        $"Es ist ein unerwarteter Fehler beim Importieren von dem Kunden mit der AmsId '{kunde.AmsId}' aufgetreten.",
                        ex);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Es ist ein unerwarteter Fehler beim Importieren von allen Kunden aufgetreten.", ex);
            throw;
        }
    }
}