using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;

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
            throw new RepositoryException($"Ein unerwarteter Fehler ist aufgetreten. KundeId: '{kunde.Id}', AmsId: '{kunde.AmsId}'.", ex);
        }
    }
}