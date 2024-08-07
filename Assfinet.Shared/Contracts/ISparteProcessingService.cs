using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface ISparteProcessingService
{
    Task ValidateSparteAsync(Sparte sparte);
    Task ProcessImportSparteAsync(Sparte sparte);
}