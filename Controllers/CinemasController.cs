using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaAPI.Models;

namespace CinemaAPI.Controllers
{
    [Route("api/Cinemas")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly CinemasContext _context;

        public CinemasController(CinemasContext context)
        {
            _context = context;
        }

        // GET: api/Cinemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemasItem>>> GetCinemas()
        {
          if (_context.CinemasItems == null)
          {
              return NotFound();
          }
            return await _context.CinemasItems.ToListAsync();
        }

        // GET: api/Cinemas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CinemasItem>> GetCinemas(long id)
        {
          if (_context.CinemasItems == null)
          {
              return NotFound();
          }
            var cinemas = await _context.CinemasItems.FindAsync(id);

            if (cinemas == null)
            {
                return NotFound();
            }

            return cinemas;
        }

        // GET: api/Cinemas/{id}/showtime
        [HttpGet("{id}/showtime")]
        public async Task<ActionResult<CinemasItem>> GetCinemasTime(long id)
        {
            if (_context.CinemasItems == null)
            {
                return NotFound();
            }
            var cinemaItem = await _context.CinemasItems.FindAsync(id);

            if (cinemaItem == null)
            {
                return NotFound();
            }

            var responseBody = CinemasItem.showTimeTable(cinemaItem.OpeningHour, cinemaItem.ClosingHour, cinemaItem.ShowDuration);

            return CreatedAtAction(nameof(GetCinemasTime), responseBody);
        }

        // PUT: api/Cinemas/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinemas(long id, CinemasItem cinemas)
        {
            if (id != cinemas.Id)
            {
                return BadRequest();
            }

            _context.Entry(cinemas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinemasExists(id))
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

        // POST: api/Cinemas/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<ActionResult<CinemasItem>> PostCinemas(long id, CinemasItem cinemas)
        {
            if (_context.CinemasItems == null)
            {
                return Problem("Entity set 'CinemasContext.Cinemas'  is null.");
            }

            cinemas.Id = id;
            _context.CinemasItems.Add(cinemas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCinemas", new { id = cinemas.Id }, cinemas);
        }

        // DELETE: api/Cinemas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinemas(long id)
        {
            if (_context.CinemasItems == null)
            {
                return NotFound();
            }
            var cinemas = await _context.CinemasItems.FindAsync(id);
            if (cinemas == null)
            {
                return NotFound();
            }

            _context.CinemasItems.Remove(cinemas);
            await _context.SaveChangesAsync();

            var responseBody = new { success = true };

            return CreatedAtAction(nameof(DeleteCinemas), responseBody);
        }

        private bool CinemasExists(long id)
        {
            return (_context.CinemasItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
