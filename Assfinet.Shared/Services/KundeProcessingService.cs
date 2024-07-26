using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Services;

public class KundeProcessingService : IKundeProcessingService
{
    private readonly IValidatorWrapper<Kunde> _kundeValidator;
    private readonly IKundeRepository _kundeRepository;
    private readonly IAppLogger _logger;

    public KundeProcessingService(IValidatorWrapper<Kunde> kundeValidator, IKundeRepository kundeRepository, IAppLogger logger)
    {
        _kundeValidator = kundeValidator;
        _kundeRepository = kundeRepository;
        _logger = logger;
    }

    public async Task ValidateKundeAsync(Kunde kunde)
    {
        await _kundeValidator.ValidateAndThrowAsync(kunde);
    }

    public async Task ProcessKundeAsync(Kunde kunde)
    {
        var kundeExists = await _kundeRepository.KundeExistsByAmsIdAsync(kunde.AmsId);

        if (kundeExists)
        {
            _logger.LogInformation(
                $"Es wird versucht, den Kunden mit der AmsId '{kunde.AmsId}' in der Datenbank zu aktualisieren.");
            await _kundeRepository.UpdateKundeAsync(kunde);
            _logger.LogInformation(
                $"Der Kunde mit der AmsId '{kunde.AmsId}' wurde erfolgreich in der Datenbank aktualisiert.");
        }
        else
        {
            _logger.LogInformation(
                $"Es wird versucht, den Kunden mit der AmsId '{kunde.AmsId}' in der Datenbank zu erstellen.");
            await _kundeRepository.AddKundeAsync(kunde);
            _logger.LogInformation(
                $"Der Kunde mit der AmsId '{kunde.AmsId}' wurde erfolgreich in der Datenbank erstellt.");
        }
    }
}
