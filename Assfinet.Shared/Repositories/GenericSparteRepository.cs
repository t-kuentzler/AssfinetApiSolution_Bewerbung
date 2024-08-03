using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Assfinet.Shared.Repositories
{
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
            try
            {
                await _dbSet.AddAsync(entity);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(
                    $"Ein unerwarteter Fehler ist beim Hinzufügen von '{typeof(T).Name}' aufgetreten.", ex);
            }
        }

        public async Task<T?> GetSparteByAmsIdAsync(Guid amsId)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(s => EF.Property<Guid>(s, "AmsId") == amsId);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(
                    $"Ein unerwarteter Fehler ist beim Abrufen von '{typeof(T).Name}' mit AmsId: '{amsId}' aufgetreten.",
                    ex);
            }
        }
    }
}