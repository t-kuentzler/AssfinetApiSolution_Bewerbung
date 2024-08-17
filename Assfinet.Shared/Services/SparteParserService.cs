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

            //Allgemeine Spartendaten mappen
            var result = _mapper.Map(sparteModel, sourceType, targetType) as Sparte;

            if (result == null)
            {
                _logger.LogError($"Mapping von '{sourceType.Name}' zu '{targetType.Name}' fehlgeschlagen.");
                throw new InvalidOperationException($"Mapping von '{sourceType.Name}' zu '{targetType.Name}' fehlgeschlagen.");
            }

            // Spezifische SpartenFields mappen
            result.SparteFields = MapAdditionalProperties((VertragSparteModel)sparteModel);

            return result;
        }

        private ICollection<SparteFields> MapAdditionalProperties(VertragSparteModel src)
        {
            // Hole alle Eigenschaftsnamen der Sparte-Klasse und speichern sie in einem HashSet(Vermeidet duplikate)
            var sparteProperties = typeof(Sparte).GetProperties().Select(p => p.Name).ToHashSet();

            // Holen alle Eigenschaftsnamen der VertragSparteModel-Klasse und speichern sie in einem HashSet
            var baseProperties = typeof(VertragSparteModel).GetProperties().Select(p => p.Name).ToHashSet();

            var additionalFields = new List<SparteFields>();

            // Iterieren über alle Eigenschaften des VertragSparteModel-Objekts
            foreach (var property in src.GetType().GetProperties())
            {
                // Prüfen, ob die Eigenschaft nicht in Sparte oder VertragSparteModel existiert und lesbar ist, um Duplikate zu vermeiden
                //Wenn nicht vorhanden bedeutet es, dass es eine Spartenspezifische Eigenschaft ist, die in SparteFields gespeichert werden soll
                if (!sparteProperties.Contains(property.Name) && !baseProperties.Contains(property.Name) && property.CanRead)
                {
                    // Hole den Wert der Eigenschaft und konvertieren ihn in einen String
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
