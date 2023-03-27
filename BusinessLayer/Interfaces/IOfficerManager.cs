using BusinessLayer.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.Interfaces
{
    public interface IOfficerManager
    {
        IList<OfficerDto> GetAll();
        OfficerDto Get(Guid id);
        bool Create(OfficerDto officerDto);
        bool Modify(OfficerDto officerDto);
        bool Delete(Guid id);
    }
}
