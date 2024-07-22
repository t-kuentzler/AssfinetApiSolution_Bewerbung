using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using AutoMapper;

namespace Assfinet.Shared.Configurations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<KundeModel, Kunde>();
    }
}