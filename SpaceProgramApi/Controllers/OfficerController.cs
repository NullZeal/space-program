using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceProgram.DataLayer.Interfaces;
using SpaceProgram.DataLayer.Models;
using SpaceProgram.DataLayer.Repositories;

namespace SpaceProgramApi.Controllers
{
    [Route("api/officer")]
    public class OfficerController : ControllerBase
    {
        private IOfficerRepository _officerRepository = new SqlServerOfficerRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Officer>> GetAll()
        {
            return Ok(_officerRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Officer> Get(Guid id)
        {
            return Ok(_officerRepository.Get(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Officer officer)
        {
            _officerRepository.Create(officer);
            return Created("", officer);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Officer officer)
        {
            _officerRepository.Modify(officer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _officerRepository.Delete(id);
            return Ok();
        }
    }
}
