using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Models;

namespace Assfinet.Shared.Services;

public class KundeService : IKundeService
{
    private readonly IKundeRepository _kundeRepository;
    private readonly IKundeParserService _kundeParserService;
    private readonly IAppLogger _logger;

    public KundeService(IKundeRepository kundeRepository, IKundeParserService kundeParserService,
        IAppLogger logger)
    {
        _kundeRepository = kundeRepository;
        _kundeParserService = kundeParserService;
        _logger = logger;
    }

    public async Task SaveKundenAsync(List<KundeModel> kunden)
    {
        try
        {
            if (kunden.Count == 0)
            {
                _logger.LogWarning("Es wurden 0 Kunden von der API abgerufen.");
                return;
            }
            else
            {
                _logger.LogInformation($"Es wurden {kunden.Count} kunden von der API abgerufen.");
            }

            foreach (var kunde in kunden)
            {
                var parsedKunde = _kundeParserService.ParseKundeModelToDbEntity(kunde);
                var kundeExists = _kundeRepository.KundeExistsByAmsIdAsync(parsedKunde.AmsId);
                if (kundeExists.Result)
                {
                    _logger.LogInformation($"Es wird versucht, den Kunden mit der AmsId '{parsedKunde.AmsId}' in der Datenbank zu erstellen.");
                    await _kundeRepository.UpdateKundeAsync(parsedKunde);
                    _logger.LogInformation($"Der Kunde mit der AmsId '{parsedKunde.AmsId}' wurde erfolgreich in der Datenbank erstellt.");
                }
                else
                {
                    _logger.LogInformation($"Es wird versucht, den Kunden mit der AmsId '{parsedKunde.AmsId}' in der Datenbank zu aktualisieren.");
                    await _kundeRepository.AddKundeAsync(parsedKunde);
                    _logger.LogInformation($"Der Kunde mit der AmsId '{parsedKunde.AmsId}' wurde erfolgreich in der Datenbank aktualisiert.");
                }
            }
        }
        catch (RepositoryException ex)
        {
            _logger.LogError($"Repository-Exception beim importieren von allen Kunden.", ex);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError("Es ist ein unerwarteter Fehler aufgetreten beim importieren von allen Kunden.", ex);
            throw new KundeServiceException();
        }

    }
}
