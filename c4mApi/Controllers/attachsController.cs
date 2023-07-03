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
    public class attachsController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public attachsController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/attach
        [HttpGet]
        public async Task<ActionResult<IEnumerable<attach>>> Getattach_tbl()
        {
            return await _context.attach_tbl.ToListAsync();
        }

        // GET: api/attach/5
        [HttpGet("{id}")]
        public async Task<ActionResult<attach>> Getattach(int id)
        {
            var attach = await _context.attach_tbl.FindAsync(id);

            if (attach == null)
            {
                return NotFound();
            }

            return attach;
        }

        // PUT: api/attach/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putattach(int id, attach attach)
        {
            if (id != attach.attach_id)
            {
                return BadRequest();
            }

            _context.Entry(attach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!attachExists(id))
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

        // POST: api/attach
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<attach>> Postattach(attach attach)
        {
            _context.attach_tbl.Add(attach);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getattach", new { id = attach.attach_id }, attach);
        }

        // DELETE: api/attach/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteattach(int id)
        {
            var attach = await _context.attach_tbl.FindAsync(id);
            if (attach == null)
            {
                return NotFound();
            }

            _context.attach_tbl.Remove(attach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool attachExists(int id)
        {
            return _context.attach_tbl.Any(e => e.attach_id == id);
        }


    }
}
