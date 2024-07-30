using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface IKundeRepository
{
    Task AddKundeAsync(Kunde kunde);
    Task UpdateKundeAsync(Kunde kunde);
    Task<Kunde?> KundeExistsByAmsIdAsync(Guid amsId);
    
}