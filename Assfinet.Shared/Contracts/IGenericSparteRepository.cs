namespace Assfinet.Shared.Contracts;

public interface IGenericSparteRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task<T?> GetSparteByAmsIdAsync(Guid amsid);
}