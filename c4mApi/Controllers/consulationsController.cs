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
    public class consulationsController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public consulationsController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/consulation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<consulation>>> Getconsulation_tbl()
        {
            return await _context.consulation_tbl.ToListAsync();
        }

        // GET: api/consulation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<consulation>> Getconsulation(int id)
        {
            var consulation = await _context.consulation_tbl.FindAsync(id);

            if (consulation == null)
            {
                return NotFound();
            }

            return consulation;
        }

        // PUT: api/consulation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putconsulation(int id, consulation consulation)
        {
            if (id != consulation.consulation_id)
            {
                return BadRequest();
            }

            _context.Entry(consulation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!consulationExists(id))
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

        // POST: api/consulation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<consulation>> Postconsulation(consulation consulation)
        {
            _context.consulation_tbl.Add(consulation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getconsulation", new { id = consulation.consulation_id }, consulation);
        }

        // DELETE: api/consulation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteconsulation(int id)
        {
            var consulation = await _context.consulation_tbl.FindAsync(id);
            if (consulation == null)
            {
                return NotFound();
            }

            _context.consulation_tbl.Remove(consulation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool consulationExists(int id)
        {
            return _context.consulation_tbl.Any(e => e.consulation_id == id);
        }


    }
}
