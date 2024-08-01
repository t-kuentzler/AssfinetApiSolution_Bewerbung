using Assfinet.Shared.Models;

namespace Assfinet.Shared.Contracts;

public interface IApiService
{
    Task<List<KundeModel>> GetKundenAsync(int skip, int take);
    Task<List<VertragModel>> GetVertraegeAsync(int skip, int take);
    Task<List<object>> GetSpartenDatenAsync(string sparte, int skip, int take);
    
}