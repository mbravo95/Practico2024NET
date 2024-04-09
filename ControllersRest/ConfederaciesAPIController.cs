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
    public class ConfederaciesAPIController : ControllerBase
    {
        private readonly DataContext _context;

        public ConfederaciesAPIController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ConfederaciesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Confederacy>>> Getconfederacies()
        {
            return await _context.confederacies.ToListAsync();
        }

        // GET: api/ConfederaciesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Confederacy>> GetConfederacy(int id)
        {
            var confederacy = await _context.confederacies.FindAsync(id);

            if (confederacy == null)
            {
                return NotFound();
            }

            return confederacy;
        }

        // PUT: api/ConfederaciesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfederacy(int id, Confederacy confederacy)
        {
            if (id != confederacy.id)
            {
                return BadRequest();
            }

            _context.Entry(confederacy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfederacyExists(id))
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

        // POST: api/ConfederaciesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Confederacy>> PostConfederacy(Confederacy confederacy)
        {
            _context.confederacies.Add(confederacy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfederacy", new { id = confederacy.id }, confederacy);
        }

        // DELETE: api/ConfederaciesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfederacy(int id)
        {
            var confederacy = await _context.confederacies.FindAsync(id);
            if (confederacy == null)
            {
                return NotFound();
            }

            _context.confederacies.Remove(confederacy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfederacyExists(int id)
        {
            return _context.confederacies.Any(e => e.id == id);
        }
    }
}
