using Assfinet.Shared.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Assfinet.Shared.Repositories;

public class GenericSparteRepository<T> : IGenericSparteRepository<T> where T : class
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly DbSet<T> _dbSet;

    public GenericSparteRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _dbSet = _applicationDbContext.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task<T?> GetSparteByAmsIdAsync(Guid amsid)
    {
        return await _dbSet.FirstOrDefaultAsync(s => EF.Property<Guid>(s, "AmsId") == amsid);
    }
}

