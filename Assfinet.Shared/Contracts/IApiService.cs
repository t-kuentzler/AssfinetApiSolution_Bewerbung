using Assfinet.Shared.Models;

namespace Assfinet.Shared.Contracts;

public interface IApiService
{
    Task<List<KundeModel>> GetKundenAsync();
    Task<List<VertragModel>> GetVertraegeAsync();
    Task<List<object>> GetSpartenDatenAsync(string sparte);
}