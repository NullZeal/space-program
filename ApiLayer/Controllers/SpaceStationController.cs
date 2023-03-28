using Microsoft.AspNetCore.Mvc;
using SpaceProgram.BusinessLayer.DtoModels;
using SpaceProgram.BusinessLayer.Interfaces;

namespace SpaceProgram.ApiLayer.Controllers;

[Route("api/spacestation")]
public class SpaceStationController : ControllerBase
{
    private ISpaceStationManager SpaceStationManager { get; }

    public SpaceStationController(ISpaceStationManager spaceStationManager)
    {
        SpaceStationManager = spaceStationManager;
    }

    [HttpGet]
    public ActionResult<IList<SpaceStationDto>> GetAll()
    {
        var fetchedSpaceStations = SpaceStationManager.GetAll();

        if (fetchedSpaceStations == null)
        {
            return Problem("An error occured while trying to find the space stations.");
        }

        return Ok(new { fetchedSpaceStations });
    }

    [HttpGet("{id}")]
    public ActionResult<SpaceStationDto> Get(Guid id)
    {
        var fetchedSpaceStation = SpaceStationManager.Get(id);

        if (fetchedSpaceStation == null)
        {
            return NotFound(new { errorMessage = "Could not find requested space station." });
        }

        return Ok(new { fetchedSpaceStation });
    }

    [HttpPost]
    public ActionResult Post([FromBody] SpaceStationDto spaceStation)
    {
        var createdSpaceStation = SpaceStationManager.Create(spaceStation);

        if (createdSpaceStation == null)
        {
            return Problem("Could not create the space station.");
        }

        return Created("", new { createdSpaceStation });
    }

    [HttpPut]
    public ActionResult Put([FromBody] SpaceStationDto spaceStation)
    {
        var originalSpaceStation = SpaceStationManager.Get(spaceStation.SpaceStationId);
        var modifiedSpaceStation = SpaceStationManager.Modify(spaceStation);

        if (modifiedSpaceStation == null)
        {
            return Problem("Could not modify the space station.");
        }

        return Ok(new { originalSpaceStation, modifiedSpaceStation });
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var deletedSpaceStation = SpaceStationManager.Delete(id);

        if (deletedSpaceStation == null)
        {
            return Problem("Could not delete the space station.");
        }

        return Ok(new { deletedSpaceStation });
    }
}