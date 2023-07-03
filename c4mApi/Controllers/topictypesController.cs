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
    public class topictypesController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public topictypesController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/topictype
        [HttpGet]
        public async Task<ActionResult<IEnumerable<topictype>>> Gettopictype_tbl()
        {
            return await _context.topictype_tbl.ToListAsync();
        }

        // GET: api/topictype/5
        [HttpGet("{id}")]
        public async Task<ActionResult<topictype>> Gettopictype(int id)
        {
            var topictype = await _context.topictype_tbl.FindAsync(id);

            if (topictype == null)
            {
                return NotFound();
            }

            return topictype;
        }

        // PUT: api/topictype/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttopictype(int id, topictype topictype)
        {
            if (id != topictype.topictype_id)
            {
                return BadRequest();
            }

            _context.Entry(topictype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!topictypeExists(id))
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

        // POST: api/topictype
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<topictype>> Posttopictype(topictype topictype)
        {
            _context.topictype_tbl.Add(topictype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettopictype", new { id = topictype.topictype_id }, topictype);
        }

        // DELETE: api/topictype/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetopictype(int id)
        {
            var topictype = await _context.topictype_tbl.FindAsync(id);
            if (topictype == null)
            {
                return NotFound();
            }

            _context.topictype_tbl.Remove(topictype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool topictypeExists(int id)
        {
            return _context.topictype_tbl.Any(e => e.topictype_id == id);
        }
    }
}
