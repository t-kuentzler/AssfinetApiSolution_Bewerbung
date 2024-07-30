using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface IKundeRepository
{
    Task AddKundeAsync(Kunde kunde);
    Task UpdateKundeAsync(Kunde kunde);
    Task<Kunde?> GetKundeByAmsIdAsync(Guid amsId);
    Task<Kunde?> GetKundeByAmsidnrAsync(string amsidnr);

}