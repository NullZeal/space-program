using SpaceProgram.BusinessLayer.DtoModels;

namespace SpaceProgram.BusinessLayer.Interfaces;

public interface ISpaceStationManager
{
    IList<SpaceStationDto>? GetAll();
    SpaceStationDto? Get(Guid id);
    SpaceStationDto? Create(SpaceStationDto spaceStationDto);
    SpaceStationDto? Modify(SpaceStationDto spaceStationDto);
    SpaceStationDto? Delete(Guid id);
}