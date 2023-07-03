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
    public class meetingtermsController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public meetingtermsController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/meetingterm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<meetingterm>>> Getmeetingterm_tbl()
        {
            return await _context.meetingterm_tbl.ToListAsync();
        }

        // GET: api/meetingterm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<meetingterm>> Getmeetingterm(int id)
        {
            var meetingterm = await _context.meetingterm_tbl.FindAsync(id);

            if (meetingterm == null)
            {
                return NotFound();
            }

            return meetingterm;
        }

        // PUT: api/meetingterm/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmeetingterm(int id, meetingterm meetingterm)
        {
            if (id != meetingterm.meetingterm_id)
            {
                return BadRequest();
            }

            _context.Entry(meetingterm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!meetingtermExists(id))
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

        // POST: api/meetingterm
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<meetingterm>> Postmeetingterm(meetingterm meetingterm)
        {
            _context.meetingterm_tbl.Add(meetingterm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmeetingterm", new { id = meetingterm.meetingterm_id }, meetingterm);
        }

        // DELETE: api/meetingterm/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemeetingterm(int id)
        {
            var meetingterm = await _context.meetingterm_tbl.FindAsync(id);
            if (meetingterm == null)
            {
                return NotFound();
            }

            _context.meetingterm_tbl.Remove(meetingterm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool meetingtermExists(int id)
        {
            return _context.meetingterm_tbl.Any(e => e.meetingterm_id == id);
        }

    }
}
