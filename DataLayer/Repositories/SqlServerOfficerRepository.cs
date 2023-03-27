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
        Database.Officer.Add(officer);
        Database.SaveChanges();
    }

    public void Modify(Officer officer)
    {
        var officerToModify = Database.Officer.Find(officer.OfficerId);
        Database.Officer.Entry(officerToModify).CurrentValues.SetValues(officer);
        Database.SaveChanges();
    }

    public void Delete(Guid id)
    {
        Officer officerToDelete = Database.Officer.Find(id);
        if (officerToDelete != null)
        {
            Database.Remove(officerToDelete);
        }
        Database.SaveChanges();
    }
}