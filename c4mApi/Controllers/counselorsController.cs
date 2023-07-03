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
    public class counselorsController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public counselorsController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/counselor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<counselor>>> Getcounselor_tbl()
        {
            return await _context.counselor_tbl.ToListAsync();
        }

        // GET: api/counselor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<counselor>> Getcounselor(int id)
        {
            var counselor = await _context.counselor_tbl.FindAsync(id);

            if (counselor == null)
            {
                return NotFound();
            }

            return counselor;
        }

        // PUT: api/counselor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcounselor(int id, counselor counselor)
        {
            if (id != counselor.counselor_id)
            {
                return BadRequest();
            }

            _context.Entry(counselor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!counselorExists(id))
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

        // POST: api/counselor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<counselor>> Postcounselor(counselor counselor)
        {
            _context.counselor_tbl.Add(counselor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcounselor", new { id = counselor.counselor_id }, counselor);
        }

        // DELETE: api/counselor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecounselor(int id)
        {
            var counselor = await _context.counselor_tbl.FindAsync(id);
            if (counselor == null)
            {
                return NotFound();
            }

            _context.counselor_tbl.Remove(counselor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool counselorExists(int id)
        {
            return _context.counselor_tbl.Any(e => e.counselor_id == id);
        }
    }
}
