using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface IKundeRepository
{
    Task AddKundeAsync(Kunde kunde);
    Task UpdateKundeAsync(Kunde kunde);
    Task<bool> KundeExistsByAmsIdAsync(Guid amsId);
}