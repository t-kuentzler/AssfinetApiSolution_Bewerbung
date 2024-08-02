using Assfinet.Shared.Enums;
using Assfinet.Shared.Models;

namespace Assfinet.Shared.Contracts;

public interface IApiService
{
    Task<List<KundeModel>> GetKundenAsync(int skip, int take);
    Task<List<VertragModel>> GetVertraegeAsync(int skip, int take);
    Task<List<object>> GetSpartenDatenAsync(Spartentypen sparte, int skip, int take);
    
}