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
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // ID wird von der Datenbank generiert

        CreateMap<KundeModel, KundePersonenDetails>()
            .ForMember(dest => dest.KundeId, opt => opt.Ignore());

        CreateMap<KundeModel, KundeFinanzen>()
            .ForMember(dest => dest.KundeId, opt => opt.Ignore());

        CreateMap<KundeModel, KundeKontakt>()
            .ForMember(dest => dest.KundeId, opt => opt.Ignore());

        CreateMap<VertragModel, Vertrag>()
            .ForMember(dest => dest.AmsId,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // ID wird von der Datenbank generiert

        CreateMap<VertragModel, VertragFinanzen>()
            .ForMember(dest => dest.VertragId, opt => opt.Ignore());

        CreateMap<VertragModel, VertragDetails>()
            .ForMember(dest => dest.VertragId, opt => opt.Ignore());

        CreateMap<VertragModel, VertragHistorie>()
            .ForMember(dest => dest.VertragId, opt => opt.Ignore());

        CreateMap<VertragModel, VertragBank>()
            .ForMember(dest => dest.VertragId, opt => opt.Ignore());

        CreateMap<VertragSparteModel, Sparte>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // ID wird von der Datenbank generiert
            .ForMember(dest => dest.AmsId, opt => opt.MapFrom(src => src.Id));

        CreateMap<UnfModel, Sparte>()
            .IncludeBase<VertragSparteModel, Sparte>();
    }
}