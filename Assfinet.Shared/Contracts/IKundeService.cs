using Assfinet.Shared.Models;

namespace Assfinet.Shared.Contracts;

public interface IKundeService
{
    Task ImportKundenAsync(List<KundeModel> kunden);
}