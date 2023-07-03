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
    public class meetingsController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public meetingsController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/meeting
        [HttpGet]
        public async Task<ActionResult<IEnumerable<meeting>>> Getmeeting_tbl()
        {
            return await _context.meeting_tbl.ToListAsync();
        }

        // GET: api/meeting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<meeting>> Getmeeting(int id)
        {
            var meeting = await _context.meeting_tbl.FindAsync(id);

            if (meeting == null)
            {
                return NotFound();
            }

            return meeting;
        }

        // PUT: api/meeting/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmeeting(int id, meeting meeting)
        {
            if (id != meeting.meeting_id)
            {
                return BadRequest();
            }

            _context.Entry(meeting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!meetingExists(id))
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

        // POST: api/meeting
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<meeting>> Postmeeting(meeting meeting)
        {
            _context.meeting_tbl.Add(meeting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmeeting", new { id = meeting.meeting_id }, meeting);
        }

        // DELETE: api/meeting/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemeeting(int id)
        {
            var meeting = await _context.meeting_tbl.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            _context.meeting_tbl.Remove(meeting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool meetingExists(int id)
        {
            return _context.meeting_tbl.Any(e => e.meeting_id == id);
        }
    }
}
