using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.DataLayer.Interfaces;

public interface IOfficerRepository
{
    public IList<Officer> GetAll();
    public Officer Get(Guid id);
    public void Create(Officer officer);
    public void Modify(Officer officer);
    void Delete(Guid id);
}