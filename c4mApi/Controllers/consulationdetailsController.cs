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
    public class consulationdetailsController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public consulationdetailsController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/consulationdetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<consulationdetail>>> Getconsulationdetail_tbl()
        {
            return await _context.consulationdetail_tbl.ToListAsync();
        }

        // GET: api/consulationdetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<consulationdetail>> Getconsulationdetail(int id)
        {
            var consulationdetail = await _context.consulationdetail_tbl.FindAsync(id);

            if (consulationdetail == null)
            {
                return NotFound();
            }

            return consulationdetail;
        }

        // PUT: api/consulationdetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putconsulationdetail(int id, consulationdetail consulationdetail)
        {
            if (id != consulationdetail.consulationdetail_id)
            {
                return BadRequest();
            }

            _context.Entry(consulationdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!consulationdetailExists(id))
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

        // POST: api/consulationdetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<consulationdetail>> Postconsulationdetail(consulationdetail consulationdetail)
        {
            _context.consulationdetail_tbl.Add(consulationdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getconsulationdetail", new { id = consulationdetail.consulationdetail_id }, consulationdetail);
        }

        // DELETE: api/consulationdetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteconsulationdetail(int id)
        {
            var consulationdetail = await _context.consulationdetail_tbl.FindAsync(id);
            if (consulationdetail == null)
            {
                return NotFound();
            }

            _context.consulationdetail_tbl.Remove(consulationdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool consulationdetailExists(int id)
        {
            return _context.consulationdetail_tbl.Any(e => e.consulationdetail_id == id);
        }

    }
}
