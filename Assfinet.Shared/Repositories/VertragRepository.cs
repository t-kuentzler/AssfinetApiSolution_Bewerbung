using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Assfinet.Shared.Repositories;

public class VertragRepository : IVertragRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public VertragRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public async Task AddVertragAsync(Vertrag vertrag)
    {
        try
        {
            _applicationDbContext.Vertraege.Add(vertrag);
            await _applicationDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new RepositoryException($"Ein unerwarteter Fehler ist aufgetreten beim erstellen des Vertrags. VertragId: '{vertrag.Id}', AmsId: '{vertrag.AmsId}'.", ex);
        }
    }
    
    public async Task UpdateVertragAsync(Vertrag vertrag)
    {
        try
        {
            _applicationDbContext.Vertraege.Update(vertrag);
            await _applicationDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new RepositoryException($"Ein unerwarteter Fehler ist aufgetreten beim aktualisieren des Vertrags. VertragId: '{vertrag.Id}', AmsId: '{vertrag.AmsId}'.", ex);
        }
    }
    
    public async Task<Vertrag?> VertragExistsByAmsIdAsync(Guid amsId)
    {
        try
        {
            return await _applicationDbContext.Vertraege.FirstOrDefaultAsync(k => k.AmsId == amsId);
        } 
        catch (Exception ex)
        {
            throw new RepositoryException($"Ein unerwarteter Fehler ist aufgetreten beim Abrufen des Vertrags mit AmsId: '{amsId}'.", ex);
        }
    }
}