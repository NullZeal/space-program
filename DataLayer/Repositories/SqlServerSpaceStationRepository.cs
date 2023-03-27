using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.DataLayer.Repositories;

public class SqlServerSpaceStationRepository : SqlServerRepository, ISpaceStationRepository
{
    public IList<SpaceStation> GetAll()
    {
        return Database.SpaceStation.ToList();
    }

    public SpaceStation Get(Guid id)
    {
        return Database.SpaceStation.Find(id);
    }

    public void Create(SpaceStation spaceStation)
    {
        Database.SpaceStation.Add(spaceStation);
        Database.SaveChanges();
    }

    public void Modify(SpaceStation spaceStation)
    {
        var spaceStationToModify = Database.SpaceStation.Find(spaceStation.SpaceStationId);
        Database.SpaceStation.Entry(spaceStationToModify).CurrentValues.SetValues(spaceStation);
        Database.SaveChanges();
    }

    public void Delete(Guid id)
    {
        SpaceStation spaceStationToDelete = Database.SpaceStation.Find(id);
        if (spaceStationToDelete != null)
        {
            Database.SpaceStation.Remove(spaceStationToDelete);
        }
        Database.SaveChanges();
    }
}