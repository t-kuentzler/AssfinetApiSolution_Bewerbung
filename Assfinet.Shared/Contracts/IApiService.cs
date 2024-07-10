using Assfinet.Shared.Models;

namespace Assfinet.Shared.Contracts;

public interface IApiService
{
    Task<List<KundeModel>> GetKundenAsync();
}