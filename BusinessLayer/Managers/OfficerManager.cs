using AutoMapper;
using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.BusinessLayer.Managers;

public class OfficerManager : IOfficerManager
{
    private IOfficerRepository OfficerRepository { get; }
    private IMapper Mapper { get; }

    public OfficerManager(IOfficerRepository officerRepository, IMapper mapper)
    {
        OfficerRepository = officerRepository;
        Mapper = mapper;
    }

    public IList<OfficerDto>?  GetAll()
    {
        try
        {
            var response = OfficerRepository.GetAll();
            return Mapper.Map<IList<OfficerDto>>(response);
        }
        catch
        {
            return null;
        }
    }

    public OfficerDto? Get(Guid id)
    {
        try 
        {
            var response = OfficerRepository.Get(id);
            return Mapper.Map<OfficerDto>(response);
        }
        catch
        {
            return null;
        }
    }

    public OfficerDto? Create(OfficerDto officerDto)
    {
        try
        {
            OfficerRepository.Create(Mapper.Map<Officer>(officerDto));
            var response = OfficerRepository.Get(officerDto.Name);
            return Mapper.Map<OfficerDto>(response);
        }
        catch
        {
            return null;
        }
    }

    public OfficerDto? Modify(OfficerDto officerDto)
    {
        try
        {
            OfficerRepository.Modify(Mapper.Map<Officer>(officerDto));
            return officerDto;
        }
        catch
        {
            return null;
        }
    }

    public OfficerDto? Delete(Guid id)
    {
        try
        {
            OfficerDto officer = Mapper.Map<OfficerDto>(OfficerRepository.Get(id));
            OfficerRepository.Delete(id);
            return officer;
        }
        catch
        {
            return null;
        }
    }
}
