using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceProgramApi.Data;
using SpaceProgramApi.Models;

namespace SpaceProgramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficersController : ControllerBase
    {
        private readonly SpaceProgramApiContext _context;

        public OfficersController(SpaceProgramApiContext context)
        {
            _context = context;
        }

        // GET: api/Officers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Officer>>> GetOfficer()
        {
          if (_context.Officer == null)
          {
              return NotFound();
          }
            return await _context.Officer.ToListAsync();
        }

        // GET: api/Officers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Officer>> GetOfficer(Guid id)
        {
          if (_context.Officer == null)
          {
              return NotFound();
          }
            var officer = await _context.Officer.FindAsync(id);

            if (officer == null)
            {
                return NotFound();
            }

            return officer;
        }

        // PUT: api/Officers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficer(Guid id, Officer officer)
        {
            if (id != officer.OfficerId)
            {
                return BadRequest();
            }

            _context.Entry(officer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Officers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Officer>> PostOfficer(Officer officer)
        {
            if (_context.Officer == null)
            {
                return Problem("Entity set 'SpaceProgramApiContext.Officer'  is null.");
            }

            if (_context.Officer.Any(x => x.Name == officer.Name))
            {
                return Problem("Officer name already exists.");
            }


            _context.Officer.Add(officer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficer", new { id = officer.OfficerId }, officer);
        }

        // DELETE: api/Officers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficer(Guid id)
        {
            if (_context.Officer == null)
            {
                return NotFound();
            }
            var officer = await _context.Officer.FindAsync(id);
            if (officer == null)
            {
                return NotFound();
            }

            _context.Officer.Remove(officer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficerExists(Guid id)
        {
            return (_context.Officer?.Any(e => e.OfficerId == id)).GetValueOrDefault();
        }
    }
}
