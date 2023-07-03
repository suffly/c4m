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
    public class ministriesController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public ministriesController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/ministry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ministry>>> Getministry_tbl()
        {
            return await _context.ministry_tbl.ToListAsync();
        }

        // GET: api/ministry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ministry>> Getministry(int id)
        {
            var ministry = await _context.ministry_tbl.FindAsync(id);

            if (ministry == null)
            {
                return NotFound();
            }

            return ministry;
        }

        // PUT: api/ministry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putministry(int id, ministry ministry)
        {
            if (id != ministry.ministry_id)
            {
                return BadRequest();
            }

            _context.Entry(ministry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ministryExists(id))
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

        // POST: api/ministry
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ministry>> Postministry(ministry ministry)
        {
            _context.ministry_tbl.Add(ministry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getministry", new { id = ministry.ministry_id }, ministry);
        }

        // DELETE: api/ministry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteministry(int id)
        {
            var ministry = await _context.ministry_tbl.FindAsync(id);
            if (ministry == null)
            {
                return NotFound();
            }

            _context.ministry_tbl.Remove(ministry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ministryExists(int id)
        {
            return _context.ministry_tbl.Any(e => e.ministry_id == id);
        }
    }
}
