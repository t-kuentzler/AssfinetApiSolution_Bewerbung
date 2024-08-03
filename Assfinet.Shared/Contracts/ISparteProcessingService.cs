using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface ISparteProcessingService
{
    Task ValidateSparteAsync(object sparte);
    Task ProcessImportSparteAsync(object sparte);
}