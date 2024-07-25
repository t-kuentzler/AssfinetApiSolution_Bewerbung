using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using AutoMapper;

namespace Assfinet.Shared.Services;

public class KundeParserService : IKundeParserService
{
    private readonly IMapper _mapper;

    public KundeParserService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Kunde ParseKundeModelToDbEntity(KundeModel kundeModel)
    {
        var kunde = _mapper.Map<Kunde>(kundeModel);
        kunde.PersonenDetails = _mapper.Map<KundePersonenDetails>(kundeModel);
        kunde.Finanzen = _mapper.Map<KundeFinanzen>(kundeModel);
        kunde.Kontakt = _mapper.Map<KundeKontakt>(kundeModel);
        
        return kunde;
    }
}