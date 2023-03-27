using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.DataLayer.Interfaces;

public interface ISpaceStationRepository
{
    public IList<SpaceStation> GetAll();
    public SpaceStation Get(Guid id);
    public void Create(SpaceStation officer);
    public void Modify(SpaceStation officer);
    void Delete(Guid id);
}