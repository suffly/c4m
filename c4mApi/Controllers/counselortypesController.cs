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
    public class counselortypesController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public counselortypesController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/counselortype
        [HttpGet]
        public async Task<ActionResult<IEnumerable<counselortype>>> Getcounselortype_tbl()
        {
            return await _context.counselortype_tbl.ToListAsync();
        }

        // GET: api/counselortype/5
        [HttpGet("{id}")]
        public async Task<ActionResult<counselortype>> Getcounselortype(int id)
        {
            var counselortype = await _context.counselortype_tbl.FindAsync(id);

            if (counselortype == null)
            {
                return NotFound();
            }

            return counselortype;
        }

        // PUT: api/counselortype/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcounselortype(int id, counselortype counselortype)
        {
            if (id != counselortype.counselortype_id)
            {
                return BadRequest();
            }

            _context.Entry(counselortype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!counselortypeExists(id))
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

        // POST: api/counselortype
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<counselortype>> Postcounselortype(counselortype counselortype)
        {
            _context.counselortype_tbl.Add(counselortype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcounselortype", new { id = counselortype.counselortype_id }, counselortype);
        }

        // DELETE: api/counselortype/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecounselortype(int id)
        {
            var counselortype = await _context.counselortype_tbl.FindAsync(id);
            if (counselortype == null)
            {
                return NotFound();
            }

            _context.counselortype_tbl.Remove(counselortype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool counselortypeExists(int id)
        {
            return _context.counselortype_tbl.Any(e => e.counselortype_id == id);
        }
    }
}
