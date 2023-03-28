using AutoMapper;
using SpaceProgram.BusinessLayer.DtoModels;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.BusinessLayer.AutoMapperProfiles;

public class SpaceStationProfile : Profile
{
    public SpaceStationProfile()
    {
        CreateMap<SpaceStationDto, SpaceStation>()
            .ForMember(destination => destination.SpaceStationId, opt => opt.MapFrom(src => src.SpaceStationId))
            .ForMember(destination => destination.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(destination => destination.OfficerList, opt => opt.Ignore());

        CreateMap<SpaceStation, SpaceStationDto>()
            .ForMember(destination => destination.SpaceStationId, opt => opt.MapFrom(src => src.SpaceStationId))
            .ForMember(destination => destination.Name, opt => opt.MapFrom(src => src.Name));
    }
}
