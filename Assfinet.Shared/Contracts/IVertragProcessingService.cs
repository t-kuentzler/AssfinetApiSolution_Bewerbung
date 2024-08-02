using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface IVertragProcessingService
{
    Task ValidateVertragAsync(Vertrag vertrag);
    Task ProcessImportVertragAsync(Vertrag vertrag);
}