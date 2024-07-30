using Assfinet.Shared.Models;

namespace Assfinet.Shared.Contracts;

public interface IVertragService
{
    Task ImportVertraegeAsync(List<VertragModel> vertraegeModels);
}