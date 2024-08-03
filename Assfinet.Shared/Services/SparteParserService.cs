using Assfinet.Shared.Contracts;
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
                _logger.LogError($"{nameof(sparteModel)} darf beim parsen nicht null sein.");
                throw new ArgumentNullException(nameof(sparteModel));
            }

            //Typ ermitteln für dynamisches mapping
            var sourceType = sparteModel.GetType();
            var targetType = GetTargetType(sourceType);

            var result = _mapper.Map(sparteModel, sourceType, targetType);

            if (result == null)
            {
                _logger.LogError($"Mapping von '{sourceType.Name}' zu '{targetType.Name}' fehlgeschlagen.");
                throw new InvalidOperationException(
                    $"Mapping von '{sourceType.Name}' zu '{targetType.Name}' fehlgeschlagen.");
            }

            return result;
        }

        private Type GetTargetType(Type sourceType)
        {
            var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
            var targetType = allTypes.FirstOrDefault(t => t.Name == sourceType.Name.Replace("Model", "Sparte"));

            if (targetType == null)
            {
                _logger.LogError($"Kein Mapping für den Typ '{sourceType.Name}' gefunden.");
                throw new InvalidOperationException($"Kein Mapping für den Typ '{sourceType.Name}' gefunden.");
            }

            return targetType;
        }
    }
}