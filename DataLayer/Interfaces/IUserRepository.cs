using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.DataLayer.Interfaces;

public interface IUserRepository
{
    public IList<User> Get();
}