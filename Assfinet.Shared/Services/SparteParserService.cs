using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;
using AutoMapper;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;

namespace Assfinet.Shared.Services;

public class SparteParserService : ISparteParserService
{
    private readonly IMapper _mapper;
    private readonly IAppLogger _logger;
    private readonly IDictionary<Type, Type> _typeMapping;

    public SparteParserService(IMapper mapper, IAppLogger logger)
    {
        _mapper = mapper;
        _logger = logger;
        _typeMapping = new Dictionary<Type, Type>
        {
            { typeof(KrvModel), typeof(KrvSparte) }
            // Weitere Typzuordnungen hinzufügen
        };
    }

    public object ParseSparteModel(object sparteModel)
    {
        try
        {
            if (sparteModel == null)
            {
                throw new ArgumentNullException(nameof(sparteModel));
            }

            var sourceType = sparteModel.GetType();
            if (!_typeMapping.TryGetValue(sourceType, out var targetType))
            {
                throw new InvalidOperationException($"Kein Mapping für den Typ '{sourceType.Name}' gefunden.");
            }

            var result = _mapper.Map(sparteModel, sourceType, targetType);

            if (result == null)
            {
                throw new InvalidOperationException(
                    $"Mapping von '{sourceType.Name}' zu '{targetType.Name}' fehlgeschlagen.");
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                "Es ist ein unerwarteter Fehler beim Parsen zu einem Zieltyp aufgetreten.",
                ex);
            throw new SparteParserServiceException();
        }
    }
}