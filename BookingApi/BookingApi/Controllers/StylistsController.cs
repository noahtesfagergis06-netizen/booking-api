using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BookingApi.Data;
using BookingApi.Models;

namespace BookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StylistsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StylistsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/stylists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stylist>>> GetStylists()
        {
            return await _context.Stylists.ToListAsync();
        }

        // GET: api/stylists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stylist>> GetStylist(int id)
        {
            var stylist = await _context.Stylists.FindAsync(id);

            if (stylist == null)
            {
                return NotFound();
            }

            return stylist;
        }

        // POST: api/stylists
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Stylist>> CreateStylist(Stylist stylist)
        {
            _context.Stylists.Add(stylist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStylist), new { id = stylist.Id }, stylist);
        }

        // PUT: api/stylists/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStylist(int id, Stylist stylist)
        {
            if (id != stylist.Id)
            {
                return BadRequest();
            }

            _context.Entry(stylist).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/stylists/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStylist(int id)
        {
            var stylist = await _context.Stylists.FindAsync(id);
            if (stylist == null)
            {
                return NotFound();
            }

            _context.Stylists.Remove(stylist);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}