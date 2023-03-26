using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.DataLayer.Repositories;

public class SqlServerOfficerRepository : SqlServerRepository, IOfficerRepository
{
    public IList<Officer> GetAll()
    {
        return Database.Officer.ToList();
    }

    public Officer Get(Guid id)
    {
        return Database.Officer.Find(id);
    }

    public void Create(Officer officer)
    {
    }

    public void Modify(Officer officer)
    {
    }

    public void Delete(Guid id)
    {
    }
}