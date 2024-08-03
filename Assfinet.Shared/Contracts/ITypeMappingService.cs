namespace Assfinet.Shared.Contracts;

public interface ITypeMappingService
{
    Type GetTargetType(Type sourceType);
}