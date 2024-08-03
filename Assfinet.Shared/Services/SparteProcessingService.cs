using Assfinet.Shared.Contracts;
using FluentValidation;

namespace Assfinet.Shared.Services;

public class SparteProcessingService : ISparteProcessingService
{
    private readonly IVertragRepository _vertragRepository;
    private readonly IAppLogger _logger;
    private readonly ISparteRepository _sparteRepository;
    private readonly IServiceProvider _serviceProvider;

    public SparteProcessingService(
        IVertragRepository vertragRepository,
        IAppLogger logger,
        ISparteRepository sparteRepository,
        IServiceProvider serviceProvider)
    {
        _vertragRepository = vertragRepository;
        _logger = logger;
        _sparteRepository = sparteRepository;
        _serviceProvider = serviceProvider;
    }
    
    public async Task ValidateSparteAsync(object sparte)
    {
        //Typ ermitteln für dynamische validation
        var validatorType = typeof(IValidator<>).MakeGenericType(sparte.GetType());
        var validator = _serviceProvider.GetService(validatorType) as IValidator;

        if (validator == null)
        {
            throw new InvalidOperationException($"Kein Validator für den Typ '{sparte.GetType().Name}' gefunden.");
        }

        var validationResult = await validator.ValidateAsync(new ValidationContext<object>(sparte));
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }

    public async Task ProcessImportSparteAsync(object sparte)
    {
        var sparteType = sparte.GetType();
        var keyProperty = sparteType.GetProperty("Key");
        var amsIdProperty = sparteType.GetProperty("AmsId");

        if (keyProperty == null || amsIdProperty == null)
        {
            throw new InvalidOperationException($"Die Eigenschaften 'Key' und 'AmsId' müssen im Typ '{sparteType.Name}' vorhanden sein.");
        }

        var key = keyProperty.GetValue(sparte) as string;
        var amsId = amsIdProperty.GetValue(sparte) as Guid?;

        if (key == null)
        {
            throw new InvalidOperationException($"Die Eigenschaft 'Key' im Typ '{sparteType.Name}' darf nicht null sein.");
        }

        if (amsId == null)
        {
            throw new InvalidOperationException($"Die Eigenschaft 'AmsId' im Typ '{sparteType.Name}' darf nicht null sein.");
        }

        var vertrag = await _vertragRepository.GetVertragByAmsidnrAsync(key);
        if (vertrag == null)
        {
            _logger.LogError($"Die Spartendaten mit dem Key '{key}' im Typ '{sparteType.Name}' konnten nicht in der Datenbank erstellt werden, da kein Vertrag mit der entsprechenden Amsidnr gefunden wurde.");
            return;
        }

        var existingSparte = await _sparteRepository.GetSparteByAmsIdAsync(amsId.Value, sparteType);
        if (existingSparte != null)
        {
            _logger.LogError($"Die Spartendaten mit der AmsId '{amsId}' im Typ '{sparteType.Name}' konnten nicht in der Datenbank erstellt werden, da schon ein Datensatz mit der AmsId existiert.");
            return;
        }

        await _sparteRepository.AddAsync(sparte);
        _logger.LogInformation($"Die Spartendaten mit der AmsId '{amsId}' im Typ '{sparteType.Name}' wurden erfolgreich in der Datenbank erstellt.");
    }
}
