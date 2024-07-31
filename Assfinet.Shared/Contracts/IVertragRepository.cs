using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface IVertragRepository
{
    Task AddVertragAsync(Vertrag vertrag);
    Task UpdateVertragAsync(Vertrag vertrag);
    Task<Vertrag?> GetVertragByAmsIdAsync(Guid amsId);
    Task<Vertrag?> GetVertragByAmsidnrAsync(string amsidnr);
}