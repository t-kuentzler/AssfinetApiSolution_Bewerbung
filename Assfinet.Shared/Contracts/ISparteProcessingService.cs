using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface ISparteProcessingService
{
    Task ValidateKrvSparteAsync(KrvSparte krvSparte);
    Task ProcessImportKrvSparteAsync(KrvSparte krvSparte);
}