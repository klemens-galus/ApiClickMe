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
    public class GAMEHsController : ControllerBase
    {
        private readonly DataContext _context;

        public GAMEHsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GAMEHs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GAMEH>>> GetGAMEH()
        {
          if (_context.GAMEH == null)
          {
              return NotFound();
          }
            return await _context.GAMEH.ToListAsync();
        }

        // GET: api/GAMEHs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GAMEH>> GetGAMEH(int id)
        {
          if (_context.GAMEH == null)
          {
              return NotFound();
          }
            var gAMEH = await _context.GAMEH.FindAsync(id);

            if (gAMEH == null)
            {
                return NotFound();
            }

            return gAMEH;
        }

        // PUT: api/GAMEHs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGAMEH(int id, GAMEH gAMEH)
        {
            if (id != gAMEH.Id)
            {
                return BadRequest();
            }

            _context.Entry(gAMEH).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GAMEHExists(id))
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

        // POST: api/GAMEHs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GAMEH>> PostGAMEH(GAMEH gAMEH)
        {
          if (_context.GAMEH == null)
          {
              return Problem("Entity set 'DataContext.GAMEH'  is null.");
          }
            _context.GAMEH.Add(gAMEH);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGAMEH", new { id = gAMEH.Id }, gAMEH);
        }

        // DELETE: api/GAMEHs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGAMEH(int id)
        {
            if (_context.GAMEH == null)
            {
                return NotFound();
            }
            var gAMEH = await _context.GAMEH.FindAsync(id);
            if (gAMEH == null)
            {
                return NotFound();
            }

            _context.GAMEH.Remove(gAMEH);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GAMEHExists(int id)
        {
            return (_context.GAMEH?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
