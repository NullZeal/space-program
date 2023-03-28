using AutoMapper;
using SpaceProgram.BusinessLayer.DtoModels;
using SpaceProgram.BusinessLayer.Interfaces;
using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.BusinessLayer.Managers;

public class UserManager : IUserManager
{
    private IUserRepository UserRepository { get; }
    private IMapper Mapper { get; }

    public UserManager(IUserRepository userRepository, IMapper mapper)
    {
        UserRepository = userRepository;
        Mapper = mapper;
    }

    public IList<UserDto>? GetAll()
    {
        try
        {
            var response = UserRepository.GetAll();
            return Mapper.Map<IList<UserDto>>(response);
        }
        catch
        {
            return null;
        }
    }

    public UserDto? Get(Guid id)
    {
        try
        {
            var response = UserRepository.Get(id);
            return Mapper.Map<UserDto>(response);
        }
        catch
        {
            return null;
        }
    }

    public UserDto? Create(UserDto userDto)
    {
        try
        {
            UserRepository.Create(Mapper.Map<User>(userDto));
            var response = UserRepository.Get(userDto.Username);
            return Mapper.Map<UserDto>(response);
        }
        catch
        {
            return null;
        }
    }

    public UserDto? Modify(UserDto userDto)
    {
        try
        {
            UserRepository.Modify(Mapper.Map<User>(userDto));
            return userDto;
        }
        catch
        {
            return null;
        }
    }

    public UserDto? Delete(Guid id)
    {
        try
        {
            UserDto userDto = Mapper.Map<UserDto>(UserRepository.Get(id));
            UserRepository.Delete(id);
            return userDto;
        }
        catch
        {
            return null;
        }
    }
}