using Microsoft.AspNetCore.Mvc;
using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Models;
using SpaceProgram.DataLayer.Repositories;

namespace SpaceProgramApi.Controllers;

[Route("api/spacestation")]
public class SpaceStationController : ControllerBase
{
    private ISpaceStationRepository _spaceStationRepository = new SqlServerSpaceStationRepository();

    [HttpGet]
    public ActionResult<IEnumerable<SpaceStation>> GetAll()
    {
        return Ok(_spaceStationRepository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<SpaceStation> Get(Guid id)
    {
        return Ok(_spaceStationRepository.Get(id));
    }

    [HttpPost]
    public ActionResult Post([FromBody] SpaceStation spaceStation)
    {
        _spaceStationRepository.Create(spaceStation);
        return Created("", spaceStation);
    }

    [HttpPut]
    public ActionResult Put([FromBody] SpaceStation spaceStation)
    {
        _spaceStationRepository.Modify(spaceStation);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        _spaceStationRepository.Delete(id);
        return Ok();
    }
}
