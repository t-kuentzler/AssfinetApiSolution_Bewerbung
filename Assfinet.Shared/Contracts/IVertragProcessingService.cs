using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface IVertragProcessingService
{
    Task ValidateKundeAsync(Vertrag vertrag);
    Task ProcessImportVertragAsync(Vertrag vertrag);
}