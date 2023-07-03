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
    public class partylistsController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public partylistsController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/partylist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<partylist>>> Getpartylist_tbl()
        {
            return await _context.partylist_tbl.ToListAsync();
        }

        // GET: api/partylist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<partylist>> Getpartylist(int id)
        {
            var partylist = await _context.partylist_tbl.FindAsync(id);

            if (partylist == null)
            {
                return NotFound();
            }

            return partylist;
        }

        // PUT: api/partylist/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpartylist(int id, partylist partylist)
        {
            if (id != partylist.partylist_id)
            {
                return BadRequest();
            }

            _context.Entry(partylist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!partylistExists(id))
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

        // POST: api/partylist
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<partylist>> Postpartylist(partylist partylist)
        {
            _context.partylist_tbl.Add(partylist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpartylist", new { id = partylist.partylist_id }, partylist);
        }

        // DELETE: api/partylist/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepartylist(int id)
        {
            var partylist = await _context.partylist_tbl.FindAsync(id);
            if (partylist == null)
            {
                return NotFound();
            }

            _context.partylist_tbl.Remove(partylist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool partylistExists(int id)
        {
            return _context.partylist_tbl.Any(e => e.partylist_id == id);
        }
    }
}
