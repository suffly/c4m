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
    public class meetingtypesController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public meetingtypesController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/meetingtype
        [HttpGet]
        public async Task<ActionResult<IEnumerable<meetingtype>>> Getmeetingtype_tbl()
        {
            return await _context.meetingtype_tbl.ToListAsync();
        }

        // GET: api/meetingtype/5
        [HttpGet("{id}")]
        public async Task<ActionResult<meetingtype>> Getmeetingtype(int id)
        {
            var meetingtype = await _context.meetingtype_tbl.FindAsync(id);

            if (meetingtype == null)
            {
                return NotFound();
            }

            return meetingtype;
        }

        // PUT: api/meetingtype/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmeetingtype(int id, meetingtype meetingtype)
        {
            if (id != meetingtype.meetingtype_id)
            {
                return BadRequest();
            }

            _context.Entry(meetingtype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!meetingtypeExists(id))
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

        // POST: api/meetingtype
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<meetingtype>> Postmeetingtype(meetingtype meetingtype)
        {
            _context.meetingtype_tbl.Add(meetingtype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmeetingtype", new { id = meetingtype.meetingtype_id }, meetingtype);
        }

        // DELETE: api/meetingtype/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemeetingtype(int id)
        {
            var meetingtype = await _context.meetingtype_tbl.FindAsync(id);
            if (meetingtype == null)
            {
                return NotFound();
            }

            _context.meetingtype_tbl.Remove(meetingtype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool meetingtypeExists(int id)
        {
            return _context.meetingtype_tbl.Any(e => e.meetingtype_id == id);
        }
    }
}
