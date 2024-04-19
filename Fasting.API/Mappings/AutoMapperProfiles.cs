using AutoMapper;
using Fasting.API.Models.Domain;
using Fasting.API.Models.Dto;

namespace Fasting.API.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AddFastRequestDto, FastDomain>().ReverseMap();
        CreateMap<FastDto, FastDomain>().ReverseMap();
        CreateMap<DurationDto, DurationDomain>().ReverseMap();
    }
}
