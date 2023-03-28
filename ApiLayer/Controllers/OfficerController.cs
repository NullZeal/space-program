using BusinessLayer.DtoModels;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SpaceProgram.ApiLayer.Controllers;

[Route("api/officer")]
public class OfficerController : ControllerBase
{
    private IOfficerManager officerManager { get; }

    public OfficerController(IOfficerManager officerManager)
    {
        this.officerManager = officerManager;
    }

    [HttpGet]
    public ActionResult<IList<OfficerDto>> GetAll()
    {
        var fetchedOfficers = officerManager.GetAll();

        if (fetchedOfficers == null) 
        { 
            return Problem ("An error occured while trying to find the officers!");
        }

        return Ok(new { fetchedOfficers });
    }

    [HttpGet("{id}")]
    public ActionResult<OfficerDto> Get(Guid id)
    {
        var fetchedOfficer = officerManager.Get(id);

        if (fetchedOfficer == null)
        {
            return NotFound(new { errorMessage = "Could not find requested officer." });
        }

        return Ok(new { fetchedOfficer });
    }

    [HttpPost]
    public ActionResult Post([FromBody] OfficerDto officer)
    {
        var createdOfficer = officerManager.Create(officer);

        if (createdOfficer == null)
        {
            return Problem( "Could not create the officer.");
        }

        return Created("", new { createdOfficer });
    }

    [HttpPut]
    public ActionResult Put([FromBody] OfficerDto officer)
    {
        var originalOfficer = officerManager.Get(officer.OfficerId);
        var modifiedOfficer = officerManager.Modify(officer);

        if (modifiedOfficer == null)
        {
            return Problem("Could not modify the officer.");
        }

        return Ok(new { originalOfficer, modifiedOfficer });
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var deletedOfficer = officerManager.Delete(id);

        if (deletedOfficer == null)
        {
            return Problem("Could not delete the officer.");
        }
        
        return Ok(new { deletedOfficer });
    }
}