using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using c4mApi.Models;
using c4mApi.Reprositories;

namespace c4mApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userlevelsController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public userlevelsController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/userlevel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userlevel>>> Getuserlevel_tbl()
        {
            return await _context.userlevel_tbl.ToListAsync();
        }

        // GET: api/userlevel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<userlevel>> Getuserlevel(int id)
        {
            var userlevel = await _context.userlevel_tbl.FindAsync(id);

            if (userlevel == null)
            {
                return NotFound();
            }

            return userlevel;
        }

        // PUT: api/userlevel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuserlevel(int id, userlevel userlevel)
        {
            if (id != userlevel.userlevel_id)
            {
                return BadRequest();
            }

            _context.Entry(userlevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userlevelExists(id))
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

        // POST: api/userlevel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<userlevel>> Postuserlevel(userlevel userlevel)
        {
            _context.userlevel_tbl.Add(userlevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getuserlevel", new { id = userlevel.userlevel_id }, userlevel);
        }

        // DELETE: api/userlevel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuserlevel(int id)
        {
            var userlevel = await _context.userlevel_tbl.FindAsync(id);
            if (userlevel == null)
            {
                return NotFound();
            }

            _context.userlevel_tbl.Remove(userlevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userlevelExists(int id)
        {
            return _context.userlevel_tbl.Any(e => e.userlevel_id == id);
        }
    }
}
