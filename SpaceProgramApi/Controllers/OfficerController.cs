using BusinessLayer.DtoModels;
using BusinessLayer.Interfaces;
using BusinessLayer.Managers;
using Microsoft.AspNetCore.Mvc;

namespace SpaceProgramApi.Controllers
{
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
            var officers = officerManager.GetAll();

            if (officers == null) 
            { 
                return NotFound(new { errorMessage = "Could not find any officers!" });
            }

            return Ok(new { officers });
        }

        //[HttpGet("{id}")]
        //public ActionResult<Officer> Get(Guid id)
        //{
        //    return Ok(_officerRepository.Get(id));
        //}

        //[HttpPost]
        //public ActionResult Post([FromBody] Officer officer)
        //{
        //    _officerRepository.Create(officer);
        //    return Created("", officer);
        //}

        //[HttpPut]
        //public ActionResult Put([FromBody] Officer officer)
        //{
        //    _officerRepository.Modify(officer);
        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete(Guid id)
        //{
        //    _officerRepository.Delete(id);
        //    return Ok();
        //}
    }
}
