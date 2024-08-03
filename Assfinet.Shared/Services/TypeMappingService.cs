using Assfinet.Shared.Contracts;

namespace Assfinet.Shared.Services
{
    public class TypeMappingService : ITypeMappingService
    {
        public Type GetTargetType(Type sourceType)
        {
            var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
            var targetType = allTypes.FirstOrDefault(t => t.Name == sourceType.Name.Replace("Model", "Sparte"));

            if (targetType == null)
            {
                throw new InvalidOperationException($"Kein Mapping für den Typ '{sourceType.Name}' gefunden.");
            }

            return targetType;
        }
    }
}