using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClickMe;
using ApiClickMe.Data;

namespace ApiClickMe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GAMEDsController : ControllerBase
    {
        private readonly DataContext _context;

        public GAMEDsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GAMEDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GAMED>>> GetGAMED()
        {
          if (_context.GAMED == null)
          {
              return NotFound();
          }
            return await _context.GAMED.ToListAsync();
        }

        // GET: api/GAMEDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GAMED>> GetGAMED(int id)
        {
          if (_context.GAMED == null)
          {
              return NotFound();
          }
            var gAMED = await _context.GAMED.FindAsync(id);

            if (gAMED == null)
            {
                return NotFound();
            }

            return gAMED;
        }

        // PUT: api/GAMEDs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGAMED(int id, GAMED gAMED)
        {
            if (id != gAMED.Id)
            {
                return BadRequest();
            }

            _context.Entry(gAMED).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GAMEDExists(id))
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

        // POST: api/GAMEDs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GAMED>> PostGAMED(GAMED gAMED)
        {
          if (_context.GAMED == null)
          {
              return Problem("Entity set 'DataContext.GAMED'  is null.");
          }
            _context.GAMED.Add(gAMED);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGAMED", new { id = gAMED.Id }, gAMED);
        }

        // DELETE: api/GAMEDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGAMED(int id)
        {
            if (_context.GAMED == null)
            {
                return NotFound();
            }
            var gAMED = await _context.GAMED.FindAsync(id);
            if (gAMED == null)
            {
                return NotFound();
            }

            _context.GAMED.Remove(gAMED);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GAMEDExists(int id)
        {
            return (_context.GAMED?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
