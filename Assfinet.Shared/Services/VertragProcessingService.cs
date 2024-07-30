using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Services;

public class VertragProcessingService : IVertragProcessingService
{
    private readonly IValidatorWrapper<Vertrag> _vertragValidator;
    private readonly IVertragRepository _vertragRepository;
    private readonly IKundeRepository _kundeRepository;
    private readonly IAppLogger _logger;

    public VertragProcessingService(IValidatorWrapper<Vertrag> vertragValidator, IVertragRepository vertragRepository,
        IKundeRepository kundeRepository, IAppLogger logger)
    {
        _vertragValidator = vertragValidator;
        _vertragRepository = vertragRepository;
        _kundeRepository = kundeRepository;
        _logger = logger;
    }

    public async Task ValidateKundeAsync(Vertrag vertrag)
    {
        await _vertragValidator.ValidateAndThrowAsync(vertrag);
    }

    public async Task ProcessImportVertragAsync(Vertrag vertrag)
    {
        //Vertrag nur erstellen, wenn der entsprechende Kunde in Db existiert
        var existingKunde = await _kundeRepository.GetKundeByAmsidnrAsync(vertrag.Key);
        if (existingKunde == null)
        {
            _logger.LogError(
                $"Der Vertrag mit dem Key '{vertrag.Key}' konnte nicht in der Datenbank erstellt werden, da kein Kunde mit der entsprechenden Amsidnr gefunden wurde.");
            return;
        }

        //Nicht erstellen, wenn Vertrag schon in Db existiert
        var existingVertrag = await _vertragRepository.GetVertragByAmsIdAsync(vertrag.AmsId);
        if (existingVertrag != null)
        {
            _logger.LogError(
                $"Der Vertrag mit der AmsId '{vertrag.AmsId}' konnte nicht in der Datenbank erstellt werden, da schon ein Datensatz mit der AmsId existiert.");
            return;
        }

        _logger.LogInformation(
            $"Es wird versucht, den Vertrag mit der AmsId '{vertrag.AmsId}' in der Datenbank zu erstellen.");
        await _vertragRepository.AddVertragAsync(vertrag);
        _logger.LogInformation(
            $"Der Vertrag mit der AmsId '{vertrag.AmsId}' wurde erfolgreich in der Datenbank erstellt.");
    }
}