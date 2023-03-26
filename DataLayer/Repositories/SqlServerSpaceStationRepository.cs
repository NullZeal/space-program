using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.DataLayer.Repositories;

public class SqlServerSpaceStationRepository : SqlServerRepository, ISpaceStationRepository
{
    public IList<SpaceStation> Get()
    {
        return Database.SpaceStation.ToList();
    }
}
