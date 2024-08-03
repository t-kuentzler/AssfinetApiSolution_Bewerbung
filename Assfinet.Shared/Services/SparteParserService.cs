using Assfinet.Shared.Contracts;
using AutoMapper;

namespace Assfinet.Shared.Services
{
    public class SparteParserService : ISparteParserService
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger _logger;
        private readonly ITypeMappingService _typeMappingService;

        public SparteParserService(IMapper mapper, IAppLogger logger,
            ITypeMappingService typeMappingService)
        {
            _mapper = mapper;
            _logger = logger;
            _typeMappingService = typeMappingService;
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
            var targetType = _typeMappingService.GetTargetType(sourceType);

            var result = _mapper.Map(sparteModel, sourceType, targetType);

            if (result == null)
            {
                _logger.LogError($"Mapping von '{sourceType.Name}' zu '{targetType.Name}' fehlgeschlagen.");
                throw new InvalidOperationException(
                    $"Mapping von '{sourceType.Name}' zu '{targetType.Name}' fehlgeschlagen.");
            }

            return result;
        }
    }
}