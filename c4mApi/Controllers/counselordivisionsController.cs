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
    public class counselordivisionsController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public counselordivisionsController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/counselordivision
        [HttpGet]
        public async Task<ActionResult<IEnumerable<counselordivision>>> Getcounselordivision_tbl()
        {
            return await _context.counselordivision_tbl.ToListAsync();
        }

        // GET: api/counselordivision/5
        [HttpGet("{id}")]
        public async Task<ActionResult<counselordivision>> Getcounselordivision(int id)
        {
            var counselordivision = await _context.counselordivision_tbl.FindAsync(id);

            if (counselordivision == null)
            {
                return NotFound();
            }

            return counselordivision;
        }

        // PUT: api/counselordivision/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcounselordivision(int id, counselordivision counselordivision)
        {
            if (id != counselordivision.counselordivision_id)
            {
                return BadRequest();
            }

            _context.Entry(counselordivision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!counselordivisionExists(id))
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

        // POST: api/counselordivision
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<counselordivision>> Postcounselordivision(counselordivision counselordivision)
        {
            _context.counselordivision_tbl.Add(counselordivision);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcounselordivision", new { id = counselordivision.counselordivision_id }, counselordivision);
        }

        // DELETE: api/counselordivision/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecounselordivision(int id)
        {
            var counselordivision = await _context.counselordivision_tbl.FindAsync(id);
            if (counselordivision == null)
            {
                return NotFound();
            }

            _context.counselordivision_tbl.Remove(counselordivision);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool counselordivisionExists(int id)
        {
            return _context.counselordivision_tbl.Any(e => e.counselordivision_id == id);
        }
    }
}
