using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaAPI.Models;
using CinemaAPI.src;

namespace CinemaAPI.Controllers
{
    [Route("api/cinemas")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly CinemasContext _context;

        public CinemasController(CinemasContext context)
        {
            _context = context;
        }

        // GET: api/cinemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemasItem>>> GetCinemas()
        {
          if (_context.CinemasItems == null)
          {
              return NotFound();
          }
            return await _context.CinemasItems.ToListAsync();
        }

        // GET: api/cinemas/{id}
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

        // GET: api/cinemas/{id}/showtime
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

            var responseBody = ShowTime.ShowTimeTable(cinemaItem.OpeningHour, cinemaItem.ClosingHour, cinemaItem.ShowDuration);

            return CreatedAtAction(nameof(GetCinemasTime), responseBody);
        }

        // PUT: api/cinemas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinemas(long id, CinemasItem cinemas)
        {
            if (ShowTime.IsTimeOutOfRange(cinemas.OpeningHour, cinemas.ClosingHour, cinemas.ShowDuration))
                return BadRequest();

            cinemas.Id = id;
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
            return CreatedAtAction(nameof(PutCinemas), cinemas);
        }

        // POST: api/cinemas/
        [HttpPost]
        public async Task<ActionResult<CinemasItem>> PostCinemas(CinemasItem cinemas)
        {
            if (_context.CinemasItems == null)
            {
                return Problem("Entity set 'CinemasContext.Cinemas'  is null.");
            }

            if (ShowTime.IsTimeOutOfRange(cinemas.OpeningHour, cinemas.ClosingHour, cinemas.ShowDuration))
                return BadRequest();

            // id from the request body will be ignored and automatically added next id
            cinemas.Id = 0;

            _context.CinemasItems.Add(cinemas);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostCinemas), cinemas);
        }

        // DELETE: api/cinemas/{id}
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
