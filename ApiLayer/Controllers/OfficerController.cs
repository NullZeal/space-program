using SpaceProgram.BusinessLayer.DtoModels;
using Microsoft.AspNetCore.Mvc;
using SpaceProgram.BusinessLayer.Interfaces;

namespace SpaceProgram.ApiLayer.Controllers;

[Route("api/officer")]
public class OfficerController : ControllerBase
{
    private IOfficerManager OfficerManager { get; }

    public OfficerController(IOfficerManager officerManager)
    {
        OfficerManager = officerManager;
    }

    [HttpGet]
    public ActionResult<IList<OfficerDto>> GetAll()
    {
        var fetchedOfficers = OfficerManager.GetAll();

        if (fetchedOfficers == null) 
        { 
            return Problem ("An error occured while trying to find the officers.");
        }

        return Ok(new { fetchedOfficers });
    }

    [HttpGet("{id}")]
    public ActionResult<OfficerDto> Get(Guid id)
    {
        var fetchedOfficer = OfficerManager.Get(id);

        if (fetchedOfficer == null)
        {
            return NotFound(new { errorMessage = "Could not find requested officer." });
        }

        return Ok(new { fetchedOfficer });
    }

    [HttpPost]
    public ActionResult Post([FromBody] OfficerDto officer)
    {
        var createdOfficer = OfficerManager.Create(officer);

        if (createdOfficer == null)
        {
            return Problem( "Could not create the officer.");
        }

        return Created("", new { createdOfficer });
    }

    [HttpPut]
    public ActionResult Put([FromBody] OfficerDto officer)
    {
        var originalOfficer = OfficerManager.Get(officer.OfficerId);
        var modifiedOfficer = OfficerManager.Modify(officer);

        if (modifiedOfficer == null)
        {
            return Problem("Could not modify the officer.");
        }

        return Ok(new { originalOfficer, modifiedOfficer });
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var deletedOfficer = OfficerManager.Delete(id);

        if (deletedOfficer == null)
        {
            return Problem("Could not delete the officer.");
        }
        
        return Ok(new { deletedOfficer });
    }
}