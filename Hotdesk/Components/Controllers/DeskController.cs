using Hotdesk.Components.Models;
using Hotdesk.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotdesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskController : ControllerBase
    {
        private readonly HotdeskContext _context;

        public DeskController(HotdeskContext context)
        {
            _context = context;
        }

        // GET: api/Desk
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desk>>> GetDesks()
        {
            return await _context.Desk.ToListAsync();
        }

        // GET: api/Desk/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Desk>> GetDesk(int id)
        {
            var desk = await _context.Desk.FindAsync(id);

            if (desk == null)
            {
                return NotFound();
            }

            return desk;
        }

        // POST: api/Desk
        [HttpPost]
        public async Task<ActionResult<Desk>> PostDesk(Desk desk)
        {
            _context.Desk.Add(desk);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDesk), new { id = desk.Id }, desk);
        }

        // PUT: api/Desk/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesk(int id, Desk desk)
        {
            if (id != desk.Id)
            {
                return BadRequest();
            }

            _context.Entry(desk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskExists(id))
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

        // DELETE: api/Desk/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesk(int id)
        {
            var desk = await _context.Desk.FindAsync(id);
            if (desk == null)
            {
                return NotFound();
            }

            _context.Desk.Remove(desk);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeskExists(int id)
        {
            return _context.Desk.Any(e => e.Id == id);
        }
    }
}