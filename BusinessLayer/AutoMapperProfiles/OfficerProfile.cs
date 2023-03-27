using AutoMapper;
using BusinessLayer.DtoModels;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.BusinessLayer.AutoMapperProfiles
{
    public class OfficerProfile : Profile
    {
        public OfficerProfile() 
        {
            CreateMap<OfficerDto, Officer>()
                .ForMember(destination => destination.OfficerId, opt => opt.MapFrom(src => src.OfficerId))
                .ForMember(destination => destination.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(destination => destination.Rank, opt => opt.MapFrom(src => src.Rank))
                .ForMember(destination => destination.SpaceStationId, opt => opt.MapFrom(src => src.SpaceStationId))
                .ForMember(destination => destination.SpaceStation, opt => opt.Ignore());

            CreateMap<Officer, OfficerDto>()
                .ForMember(destination => destination.OfficerId, opt => opt.MapFrom(src => src.OfficerId))
                .ForMember(destination => destination.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(destination => destination.Rank, opt => opt.MapFrom(src => src.Rank))
                .ForMember(destination => destination.SpaceStationId, opt => opt.MapFrom(src => src.SpaceStationId));
        }
    }
}
