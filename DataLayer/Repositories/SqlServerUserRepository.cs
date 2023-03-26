using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.DataLayer.Repositories;

public class SqlServerUserRepository : SqlServerRepository, IUserRepository
{
    public IList<User> Get()
    {
        return Database.User.ToList();
    }
}
