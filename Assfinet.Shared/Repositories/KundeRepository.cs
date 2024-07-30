using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Assfinet.Shared.Repositories;

public class KundeRepository : IKundeRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public KundeRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task AddKundeAsync(Kunde kunde)
    {
        try
        {
            _applicationDbContext.Kunden.Add(kunde);
            await _applicationDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new RepositoryException($"Ein unerwarteter Fehler ist aufgetreten beim erstellen des Kunden. KundeId: '{kunde.Id}', AmsId: '{kunde.AmsId}'.", ex);
        }
    }

    public async Task UpdateKundeAsync(Kunde kunde)
    {
        try
        {
            _applicationDbContext.Kunden.Update(kunde);
            await _applicationDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new RepositoryException($"Ein unerwarteter Fehler ist aufgetreten beim aktualisieren des Kunden. KundeId: '{kunde.Id}', AmsId: '{kunde.AmsId}'.", ex);
        }
    }

    public async Task<Kunde?> GetKundeByAmsIdAsync(Guid amsId)
    {
        try
        {
            return await _applicationDbContext.Kunden.FirstOrDefaultAsync(k => k.AmsId == amsId);
        } 
        catch (Exception ex)
        {
            throw new RepositoryException($"Ein unerwarteter Fehler ist aufgetreten beim Abrufen des Kunden mit AmsId: '{amsId}'.", ex);
        }
    }
    
    public async Task<Kunde?> GetKundeByAmsidnrAsync(string amsidnr)
    {
        try
        {
            return await _applicationDbContext.Kunden.FirstOrDefaultAsync(k => k.Amsidnr == amsidnr);
        } 
        catch (Exception ex)
        {
            throw new RepositoryException($"Ein unerwarteter Fehler ist aufgetreten beim Abrufen des Kunden mit Amsidnr: '{amsidnr}'.", ex);
        }
    }
    
    
}