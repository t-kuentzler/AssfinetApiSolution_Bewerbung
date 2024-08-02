namespace Assfinet.Shared.Contracts;

public interface ISparteRepository
{
    Task AddAsync(object sparte);
    Task<object?> GetSparteByAmsIdAsync(Guid amsId, Type sparteType);
}