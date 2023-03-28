using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.DataLayer.Repositories;

public class SqlServerUserRepository : SqlServerRepository, IUserRepository
{
    public IList<User> GetAll()
    {
        return Database.User.ToList();
    }

    public User Get(Guid id)
    {
        return Database.User.Find(id);
    }

    public User Get(string username)
    {
        return Database.User.Where(x => x.Username == username).FirstOrDefault();
    }

    public void Create(User user)
    {
        Database.User.Add(user);
        Database.SaveChanges();
    }

    public void Modify(User user)
    {
        var userToModify = Database.User.Find(user.UserId);
        Database.User.Entry(userToModify).CurrentValues.SetValues(user);
        Database.SaveChanges();
    }

    public void Delete(Guid id)
    {
        User userToDelete = Database.User.Find(id);
        if (userToDelete != null)
        {
            Database.User.Remove(userToDelete);
        }
        Database.SaveChanges();
    }
}
