using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.DataLayer.Interfaces;

public interface ISpaceStationRepository
{
    public IList<SpaceStation> Get();
}