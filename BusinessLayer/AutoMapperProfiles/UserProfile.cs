using AutoMapper;
using SpaceProgram.BusinessLayer.DtoModels;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.BusinessLayer.AutoMapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>()
            .ForMember(destination => destination.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(destination => destination.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(destination => destination.Password, opt => opt.MapFrom(src => src.Password));

        CreateMap<User, UserDto>()
            .ForMember(destination => destination.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(destination => destination.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(destination => destination.Password, opt => opt.MapFrom(src => src.Password));
    }
}
