using Assfinet.Shared.Models;

namespace Assfinet.Shared.Contracts;

public interface IAssfinetApiService
{
    Task<List<KundeModel>> GetKundenAsync();
}