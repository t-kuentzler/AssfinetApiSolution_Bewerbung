using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Services;

public class SparteProcessingService : ISparteProcessingService
{
    private readonly IValidatorWrapper<KrvSparte> _krvSparteValidator;
    private readonly IGenericSparteRepository<KrvSparte> _krvRepository;
    private readonly IVertragRepository _vertragRepository;
    private readonly IAppLogger _logger;

    public SparteProcessingService(
        IValidatorWrapper<KrvSparte> krvSparteValidator,
        IGenericSparteRepository<KrvSparte> krvRepository,
        IVertragRepository vertragRepository,
        IAppLogger logger)
    {
        _krvSparteValidator = krvSparteValidator;
        _krvRepository = krvRepository;
        _vertragRepository = vertragRepository;
        _logger = logger;
    }

    public async Task ValidateKrvSparteAsync(KrvSparte krvSparte)
    {
        await _krvSparteValidator.ValidateAndThrowAsync(krvSparte);
    }

    public async Task ProcessImportKrvSparteAsync(KrvSparte krvSparte)
    {
        var vertrag = await _vertragRepository.GetVertragByAmsidnrAsync(krvSparte.Key);
        if (vertrag == null)
        {
            _logger.LogError(
                $"Die Spartendaten mit dem Key '{krvSparte.Key}' konnten nicht in der Datenbank erstellt werden, da kein Vertrag mit der entsprechenden Amsidnr gefunden wurde.");
            return;
        }

        var existingSparte = await _krvRepository.GetSparteByAmsIdAsync(krvSparte.AmsId);
        if (existingSparte != null)
        {
            _logger.LogError(
                $"Die Spartendaten mit der AmsId '{krvSparte.AmsId}' konnte nicht in der Datenbank erstellt werden, da schon ein Datensatz mit der AmsId existiert.");
            return;
        }

        await _krvRepository.AddAsync(krvSparte);
        _logger.LogInformation(
            $"Die Spartendaten mit der AmsId '{vertrag.AmsId}' wurde erfolgreich in der Datenbank erstellt.");    }
}