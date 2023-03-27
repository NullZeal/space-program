using AutoMapper;
using BusinessLayer.DtoModels;
using BusinessLayer.Interfaces;
using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Repositories;

namespace BusinessLayer.Managers;

public class OfficerManager : IOfficerManager
{
    private IOfficerRepository _officerRepository { get; }
    private IMapper Mapper { get; }

    public OfficerManager(IOfficerRepository officerRepository, IMapper mapper)
    {
        _officerRepository = new SqlServerOfficerRepository();
        Mapper = mapper;
    }

    public IList<OfficerDto> GetAll()
    {
        var response = _officerRepository.GetAll();
        return Mapper.Map<IList<OfficerDto>>(response);
    }

    public OfficerDto Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Create(OfficerDto officerDto)
    {
        throw new NotImplementedException();
    }

    public bool Modify(OfficerDto officerDto)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
