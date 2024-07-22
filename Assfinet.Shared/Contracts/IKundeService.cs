using Assfinet.Shared.Models;

namespace Assfinet.Shared.Contracts;

public interface IKundeService
{
    Task SaveKundenAsync(IEnumerable<KundeModel> kunden);
}