using AutoMapper;
using SpaceProgram.BusinessLayer.DtoModels;
using SpaceProgram.BusinessLayer.Interfaces;
using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.BusinessLayer.Managers;

public class SpaceStationManager : ISpaceStationManager
{
    private ISpaceStationRepository SpaceStationRepository { get; }
    private IMapper Mapper { get; }

    public SpaceStationManager(ISpaceStationRepository spaceStationRepository, IMapper mapper)
    {
        SpaceStationRepository = spaceStationRepository;
        Mapper = mapper;
    }

    public IList<SpaceStationDto>? GetAll()
    {
        try
        {
            var response = SpaceStationRepository.GetAll();
            return Mapper.Map<IList<SpaceStationDto>>(response);
        }
        catch
        {
            return null;
        }
    }

    public SpaceStationDto? Get(Guid id)
    {
        try
        {
            var response = SpaceStationRepository.Get(id);
            return Mapper.Map<SpaceStationDto>(response);
        }
        catch
        {
            return null;
        }
    }

    public SpaceStationDto? Create(SpaceStationDto spaceStationDto)
    {
        try
        {
            SpaceStationRepository.Create(Mapper.Map<SpaceStation>(spaceStationDto));
            var response = SpaceStationRepository.Get(spaceStationDto.Name);
            return Mapper.Map<SpaceStationDto>(response);
        }
        catch
        {
            return null;
        }
    }

    public SpaceStationDto? Modify(SpaceStationDto spaceStationDto)
    {
        try
        {
            SpaceStationRepository.Modify(Mapper.Map<SpaceStation>(spaceStationDto));
            return spaceStationDto;
        }
        catch
        {
            return null;
        }
    }

    public SpaceStationDto? Delete(Guid id)
    {
        try
        {
            SpaceStationDto spaceStation = Mapper.Map<SpaceStationDto>(SpaceStationRepository.Get(id));
            SpaceStationRepository.Delete(id);
            return spaceStation;
        }
        catch
        {
            return null;
        }
    }
}
