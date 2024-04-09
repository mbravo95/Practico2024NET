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
    public class CountriesAPIController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesAPIController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CountriesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Getcountries()
        {
            return await _context.countries.ToListAsync();
        }

        // GET: api/CountriesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/CountriesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/CountriesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _context.countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.id }, country);
        }

        // DELETE: api/CountriesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _context.countries.Any(e => e.id == id);
        }
    }
}
