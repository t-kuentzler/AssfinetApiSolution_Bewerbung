using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Services;

public class KundeProcessingService : IKundeProcessingService
{
    private readonly IValidatorWrapper<Kunde> _kundeValidator;
    private readonly IKundeRepository _kundeRepository;
    private readonly IAppLogger _logger;

    public KundeProcessingService(IValidatorWrapper<Kunde> kundeValidator, IKundeRepository kundeRepository,
        IAppLogger logger)
    {
        _kundeValidator = kundeValidator;
        _kundeRepository = kundeRepository;
        _logger = logger;
    }

    public async Task ValidateKundeAsync(Kunde kunde)
    {
        await _kundeValidator.ValidateAndThrowAsync(kunde);
    }

    public async Task ProcessImportKundeAsync(Kunde kunde)
    {
        var kundeExists = await _kundeRepository.GetKundeByAmsIdAsync(kunde.AmsId);

        if (kundeExists != null)
        {
            _logger.LogError(
                $"Der Kunde mit der AmsId '{kunde.AmsId}' konnte nicht in der Datenbank erstellt werden, da schon ein Datensatz mit der AmsId existiert.");
        }

        _logger.LogInformation(
            $"Es wird versucht, den Kunden mit der AmsId '{kunde.AmsId}' in der Datenbank zu erstellen.");
        await _kundeRepository.AddKundeAsync(kunde);
        _logger.LogInformation(
            $"Der Kunde mit der AmsId '{kunde.AmsId}' wurde erfolgreich in der Datenbank erstellt.");
    }
}