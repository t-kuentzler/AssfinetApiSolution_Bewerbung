using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Services;

public class VertragProcessingService : IVertragProcessingService
{
    private readonly IValidatorWrapper<Vertrag> _vertragValidator;
    private readonly IVertragRepository _vertragRepository;
    private readonly IAppLogger _logger;

    public VertragProcessingService(IValidatorWrapper<Vertrag> vertragValidator, IVertragRepository vertragRepository, IAppLogger logger)
    {
        _vertragValidator = vertragValidator;
        _vertragRepository = vertragRepository;
        _logger = logger;
    }
    
    public async Task ValidateKundeAsync(Vertrag vertrag)
    {
        await _vertragValidator.ValidateAndThrowAsync(vertrag);
    }
    
    public async Task ProcessImportVertragAsync(Vertrag vertrag)
    {
        var vertragExists = await _vertragRepository.VertragExistsByAmsIdAsync(vertrag.AmsId);

        if (vertragExists == null)
        {
            _logger.LogInformation(
                $"Es wird versucht, den Vertrag mit der AmsId '{vertrag.AmsId}' in der Datenbank zu erstellen.");
            await _vertragRepository.AddVertragAsync(vertrag);
            _logger.LogInformation(
                $"Der Vertrag mit der AmsId '{vertrag.AmsId}' wurde erfolgreich in der Datenbank erstellt.");
        }
        else
        {
            _logger.LogError(
                $"Der Vertrag mit der AmsId '{vertrag.AmsId}' konnte nicht in der Datenbank erstellt werden, da schon ein Datensatz mit der AmsId existiert.");
        }
    }
}