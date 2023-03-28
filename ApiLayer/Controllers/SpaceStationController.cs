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
        var fetchedOfficers = SpaceStationManager.GetAll();

        if (fetchedOfficers == null)
        {
            return Problem("An error occured while trying to find the officers!");
        }

        return Ok(new { fetchedOfficers });
    }

    //[HttpGet("{id}")]
    //public ActionResult<OfficerDto> Get(Guid id)
    //{
    //    var fetchedOfficer = spaceStationManager.Get(id);

    //    if (fetchedOfficer == null)
    //    {
    //        return NotFound(new { errorMessage = "Could not find requested officer." });
    //    }

    //    return Ok(new { fetchedOfficer });
    //}

    //[HttpPost]
    //public ActionResult Post([FromBody] OfficerDto officer)
    //{
    //    var createdOfficer = spaceStationManager.Create(officer);

    //    if (createdOfficer == null)
    //    {
    //        return Problem("Could not create the officer.");
    //    }

    //    return Created("", new { createdOfficer });
    //}

    //[HttpPut]
    //public ActionResult Put([FromBody] OfficerDto officer)
    //{
    //    var originalOfficer = spaceStationManager.Get(officer.OfficerId);
    //    var modifiedOfficer = spaceStationManager.Modify(officer);

    //    if (modifiedOfficer == null)
    //    {
    //        return Problem("Could not modify the officer.");
    //    }

    //    return Ok(new { originalOfficer, modifiedOfficer });
    //}

    //[HttpDelete("{id}")]
    //public ActionResult Delete(Guid id)
    //{
    //    var deletedOfficer = spaceStationManager.Delete(id);

    //    if (deletedOfficer == null)
    //    {
    //        return Problem("Could not delete the officer.");
    //    }

    //    return Ok(new { deletedOfficer });
    //}
}