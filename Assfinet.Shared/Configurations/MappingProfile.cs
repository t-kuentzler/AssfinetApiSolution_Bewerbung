using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using AutoMapper;

namespace Assfinet.Shared.Configurations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<KundeModel, Kunde>()
            .ForMember(dest => dest.AmsId,
                opt => opt.MapFrom(src => src.Id)) // Mapping von Id in KundeModel auf AmsId in Kunde
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // ID in Kunde wird von der Datenbank generiert

        CreateMap<KundeModel, KundePersonenDetails>()
            .ForMember(dest => dest.KundeId, opt => opt.Ignore());

        CreateMap<KundeModel, KundeFinanzen>()
            .ForMember(dest => dest.KundeId, opt => opt.Ignore());

        CreateMap<KundeModel, KundeKontakt>()
            .ForMember(dest => dest.KundeId, opt => opt.Ignore());

        CreateMap<VertragModel, Vertrag>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // ID in Vertrag wird von der Datenbank generiert
    }
}