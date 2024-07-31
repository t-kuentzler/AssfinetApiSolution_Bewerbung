using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assfinet.Shared.Repositories
{
    public class SparteRepository<T> : ISparteRepository<T> where T : class, IVertragKeyProvider
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SparteRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddSparteAsync(T sparte)
        {
            _applicationDbContext.Set<T>().Add(sparte);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<T?> GetSparteByAmsidnrAsync(string amsidnr)
        {
            try
            {
                return await _applicationDbContext.Set<T>().FirstOrDefaultAsync(k => k.Key == amsidnr);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Ein unerwarteter Fehler ist aufgetreten beim Abrufen der Spartendaten mit Amsidnr: '{amsidnr}'.", ex);
            }
        }
    }
}