using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Models;
using SpaceProgram.DataLayer.Repositories;

namespace SpaceProgramApi.Controllers;

[Route("api/spacestation")]
public class SpaceStationsController : ControllerBase
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

    [HttpPut("{id}")]
    public ActionResult<SpaceStation> Put(SpaceStation spaceStation)
    {
        _spaceStationRepository.Modify(spaceStation);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<SpaceStation>> PostSpaceStation(SpaceStation spaceStation)
    {
        _spaceStationRepository.Create(spaceStation);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpaceStation(Guid id)
    {
        _spaceStationRepository.Delete(id);
        return Ok();
    }
}
