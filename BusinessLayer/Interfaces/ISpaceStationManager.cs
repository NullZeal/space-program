namespace SpaceProgram.BusinessLayer.Inferfaces;

public interface ISpaceStationManager
{
    IList<SpaceStationDto>? GetAll();
    OfficerDto? Get(Guid id);
    OfficerDto? Create(OfficerDto officerDto);
    OfficerDto? Modify(OfficerDto officerDto);
    OfficerDto? Delete(Guid id);
}