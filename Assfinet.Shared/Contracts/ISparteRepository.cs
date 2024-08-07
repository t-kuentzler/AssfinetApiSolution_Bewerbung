using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface ISparteRepository
{
    Task AddSparteAsync(Sparte sparte);
    Task<Sparte?> GetSparteByAmsIdAsync(Guid amsId);
    
}