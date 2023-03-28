namespace SpaceProgram.BusinessLayer.Inferfaces;

public interface IOfficerManager
{
    IList<OfficerDto>? GetAll();
    OfficerDto? Get(Guid id);
    OfficerDto? Create(OfficerDto officerDto);
    OfficerDto? Modify(OfficerDto officerDto);
    OfficerDto? Delete(Guid id);
}
