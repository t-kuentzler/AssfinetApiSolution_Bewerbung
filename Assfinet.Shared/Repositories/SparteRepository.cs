using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Assfinet.Shared.Repositories
{
    public class SparteRepository : ISparteRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SparteRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddSparteAsync(Sparte sparte)
        {
            try
            {
                _applicationDbContext.Sparten.Add(sparte);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(
                    $"Ein unerwarteter Fehler ist aufgetreten beim erstellen der Spartendaten. AmsId: '{sparte.AmsId}'.",
                    ex);
            }
        }

        public async Task<Sparte?> GetSparteByAmsIdAsync(Guid amsId)
        {
            try
            {
                return await _applicationDbContext.Sparten.FirstOrDefaultAsync(s => s.AmsId == amsId);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(
                    $"Ein unerwarteter Fehler ist aufgetreten beim Abrufen der Spartendaten mit der AmsId '{amsId}'.",
                    ex);
            }
        }
    }
}