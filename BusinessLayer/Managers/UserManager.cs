using SpaceProgram.BusinessLayer.DtoModels;
using SpaceProgram.BusinessLayer.Interfaces;

namespace SpaceProgram.BusinessLayer.Managers;

public class UserManager : IUserManager
{
    public UserDto? Create(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public UserDto? Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public UserDto? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IList<UserDto>? GetAll()
    {
        throw new NotImplementedException();
    }

    public UserDto? Modify(UserDto userDto)
    {
        throw new NotImplementedException();
    }
}
