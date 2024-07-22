using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;

namespace Assfinet.Shared.Services;

public class KundeParserService : IKundeParserService
{
    public KundeParserService()
    {
        
    }

    public Kunde ParseKundeModelToDbEntity(KundeModel kundeModel)
    {
        return new Kunde();
    }
}