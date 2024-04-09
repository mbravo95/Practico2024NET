using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practico2024NET.Domain;
using Practico2024NET.Persistence;

namespace Practico2024NET.ControllersRest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsAPIController : ControllerBase
    {
        private readonly DataContext _context;

        public SportsAPIController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SportsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sport>>> Getsports()
        {
            return await _context.sports.ToListAsync();
        }

        // GET: api/SportsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sport>> GetSport(int id)
        {
            var sport = await _context.sports.FindAsync(id);

            if (sport == null)
            {
                return NotFound();
            }

            return sport;
        }

        // PUT: api/SportsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSport(int id, Sport sport)
        {
            if (id != sport.id)
            {
                return BadRequest();
            }

            _context.Entry(sport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportExists(id))
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

        // POST: api/SportsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sport>> PostSport(Sport sport)
        {
            _context.sports.Add(sport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSport", new { sport.id }, sport);
        }

        // DELETE: api/SportsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSport(int id)
        {
            var sport = await _context.sports.FindAsync(id);
            if (sport == null)
            {
                return NotFound();
            }

            _context.sports.Remove(sport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SportExists(int id)
        {
            return _context.sports.Any(e => e.id == id);
        }
    }
}
