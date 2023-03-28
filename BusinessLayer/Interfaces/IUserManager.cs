using SpaceProgram.BusinessLayer.DtoModels;

namespace SpaceProgram.BusinessLayer.Interfaces;

public interface IUserManager
{
    IList<UserDto>? GetAll();
    UserDto? Get(Guid id);
    UserDto? Create(UserDto userDto);
    UserDto? Modify(UserDto userDto);
    UserDto? Delete(Guid id);
}