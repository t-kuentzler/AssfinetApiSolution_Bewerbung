using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Services;

public class SparteProcessingService : ISparteProcessingService
{
    private readonly IVertragRepository _vertragRepository;
    private readonly IAppLogger _logger;
    private readonly ISparteRepository _sparteRepository;
    private readonly IValidatorWrapper<Sparte> _sparteValidator;

    public SparteProcessingService(
        IVertragRepository vertragRepository,
        IAppLogger logger,
        ISparteRepository sparteRepository,
        IValidatorWrapper<Sparte> sparteValidator)
    {
        _vertragRepository = vertragRepository;
        _logger = logger;
        _sparteRepository = sparteRepository;
        _sparteValidator = sparteValidator;
    }
    
    public async Task ValidateSparteAsync(Sparte sparte)
    {
        await _sparteValidator.ValidateAndThrowAsync(sparte);
    }

    public async Task ProcessImportSparteAsync(Sparte sparte)
    {
        var vertrag = await _vertragRepository.GetVertragByAmsidnrAsync(sparte.Key);
        if (vertrag == null)
        {
            _logger.LogError($"Die Spartendaten mit dem Key '{sparte.Key}' konnten nicht in der Datenbank erstellt werden, da kein Vertrag mit der entsprechenden Amsidnr gefunden wurde.");
            return;
        }

        var existingSparte = await _sparteRepository.GetSparteByAmsIdAsync(sparte.AmsId);
        if (existingSparte != null)
        {
            _logger.LogError($"Die Spartendaten mit der AmsId '{sparte.AmsId}' konnten nicht in der Datenbank erstellt werden, da schon ein Datensatz mit der AmsId existiert.");
            return;
        }

        await _sparteRepository.AddSparteAsync(sparte);
        _logger.LogInformation($"Die Spartendaten mit der AmsId '{sparte.AmsId}' wurden erfolgreich in der Datenbank erstellt.");
    }
}
