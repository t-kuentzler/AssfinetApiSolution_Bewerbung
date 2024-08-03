using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using AutoMapper;

namespace Assfinet.Shared.Services;

public class VertragParserService : IVertragParserService
{
    private readonly IMapper _mapper;

    public VertragParserService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Vertrag ParseKundeModelToDbEntity(VertragModel vertragModel)
    {
        if (vertragModel == null)
        {
            throw new ArgumentNullException(nameof(vertragModel));
        }

        var vertrag = _mapper.Map<Vertrag>(vertragModel);
        if (vertrag == null)
        {
            throw new InvalidOperationException("Mapping von VertragModel zu Vertrag fehlgeschlagen.");
        }

        vertrag.Finanzen = _mapper.Map<VertragFinanzen>(vertragModel) ?? new VertragFinanzen();
        vertrag.VertragDetails = _mapper.Map<VertragDetails>(vertragModel) ?? new VertragDetails();
        vertrag.Historie = _mapper.Map<VertragHistorie>(vertragModel) ?? new VertragHistorie();
        vertrag.BankDetails = _mapper.Map<VertragBank>(vertragModel) ?? new VertragBank();

        return vertrag;
    }
}