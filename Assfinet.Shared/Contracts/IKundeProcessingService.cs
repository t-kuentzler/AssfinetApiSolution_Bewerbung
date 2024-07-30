using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface IKundeProcessingService
{
    Task ValidateKundeAsync(Kunde kunde);
    Task ProcessImportKundeAsync(Kunde kunde);
}
