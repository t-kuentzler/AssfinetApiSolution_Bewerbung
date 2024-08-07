using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using AutoMapper;

namespace Assfinet.Shared.Services
{
    public class SparteParserService : ISparteParserService
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger _logger;

        public SparteParserService(IMapper mapper, IAppLogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public object ParseSparteModel(object sparteModel)
        {
            if (sparteModel == null)
            {
                _logger.LogError($"{nameof(sparteModel)} darf beim Parsen nicht null sein.");
                throw new ArgumentNullException(nameof(sparteModel));
            }

            // Typ ermitteln für dynamisches Mapping
            var sourceType = sparteModel.GetType();
            var targetType = typeof(Sparte);

            // Map basic properties
            var result = _mapper.Map(sparteModel, sourceType, targetType) as Sparte;

            if (result == null)
            {
                _logger.LogError($"Mapping von '{sourceType.Name}' zu '{targetType.Name}' fehlgeschlagen.");
                throw new InvalidOperationException($"Mapping von '{sourceType.Name}' zu '{targetType.Name}' fehlgeschlagen.");
            }

            // Map additional properties to SparteFields
            result.SparteFields = MapAdditionalProperties((VertragSparteModel)sparteModel);

            return result;
        }

        private ICollection<SparteFields> MapAdditionalProperties(VertragSparteModel src)
        {
            var sparteProperties = typeof(Sparte).GetProperties().Select(p => p.Name).ToHashSet();
            var baseProperties = typeof(VertragSparteModel).GetProperties().Select(p => p.Name).ToHashSet();
            var additionalFields = new List<SparteFields>();

            foreach (var property in src.GetType().GetProperties())
            {
                if (!sparteProperties.Contains(property.Name) && !baseProperties.Contains(property.Name) && property.CanRead)
                {
                    var value = property.GetValue(src)?.ToString();
                    additionalFields.Add(new SparteFields
                    {
                        FieldName = property.Name,
                        FieldValue = value
                    });
                }
            }

            return additionalFields;
        }
    }
}
