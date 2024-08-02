using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface ISparteProcessingService
{
    Task ValidateAndProcessSparteAsync(object sparte);
}