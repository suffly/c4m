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
    public class statussController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public statussController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<status>>> Getstatus_tbl()
        {
            return await _context.status_tbl.ToListAsync();
        }

        // GET: api/status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<status>> Getstatus(int id)
        {
            var status = await _context.status_tbl.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return status;
        }

        // PUT: api/status/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putstatus(int id, status status)
        {
            if (id != status.status_id)
            {
                return BadRequest();
            }

            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!statusExists(id))
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

        // POST: api/status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<status>> Poststatus(status status)
        {
            _context.status_tbl.Add(status);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getstatus", new { id = status.status_id }, status);
        }

        // DELETE: api/status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletestatus(int id)
        {
            var status = await _context.status_tbl.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.status_tbl.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool statusExists(int id)
        {
            return _context.status_tbl.Any(e => e.status_id == id);
        }
    }
}
