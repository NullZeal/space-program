using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceProgram.DataLayer.EntityFramework;
using SpaceProgramApi.Models;

namespace SpaceProgramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceStationsController : ControllerBase
    {
        private readonly SpaceProgramContext _context;

        public SpaceStationsController(SpaceProgramContext context)
        {
            _context = context;
        }

        // GET: api/SpaceStations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpaceStation>>> GetSpaceStation()
        {
          if (_context.SpaceStation == null)
          {
              return NotFound();
          }
            return await _context.SpaceStation.ToListAsync();
        }

        // GET: api/SpaceStations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpaceStation>> GetSpaceStation(Guid id)
        {
          if (_context.SpaceStation == null)
          {
              return NotFound();
          }
            var spaceStation = await _context.SpaceStation.FindAsync(id);

            if (spaceStation == null)
            {
                return NotFound();
            }

            return spaceStation;
        }

        // PUT: api/SpaceStations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpaceStation(Guid id, SpaceStation spaceStation)
        {
            if (id != spaceStation.SpaceStationId)
            {
                return BadRequest();
            }

            _context.Entry(spaceStation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpaceStationExists(id))
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

        // POST: api/SpaceStations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpaceStation>> PostSpaceStation(SpaceStation spaceStation)
        {
          if (_context.SpaceStation == null)
          {
              return Problem("Entity set 'SpaceProgramApiContext.SpaceStation'  is null.");
          }
            _context.SpaceStation.Add(spaceStation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpaceStation", new { id = spaceStation.SpaceStationId }, spaceStation);
        }

        // DELETE: api/SpaceStations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpaceStation(Guid id)
        {
            if (_context.SpaceStation == null)
            {
                return NotFound();
            }
            var spaceStation = await _context.SpaceStation.FindAsync(id);
            if (spaceStation == null)
            {
                return NotFound();
            }

            _context.SpaceStation.Remove(spaceStation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpaceStationExists(Guid id)
        {
            return (_context.SpaceStation?.Any(e => e.SpaceStationId == id)).GetValueOrDefault();
        }
    }
}
