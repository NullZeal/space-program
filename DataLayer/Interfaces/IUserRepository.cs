using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.DataLayer.Interfaces;

public interface IUserRepository
{
    public IList<User> GetAll();
    public User Get(Guid id);
    public void Create(User officer);
    public void Modify(User officer);
    void Delete(Guid id);
}