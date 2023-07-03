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
    public class userprofilesController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public userprofilesController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/userprofile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userprofile>>> Getuserprofile_tbl()
        {
            return await _context.userprofile_tbl.ToListAsync();
        }

        // GET: api/userprofile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<userprofile>> Getuserprofile(int id)
        {
            var userprofile = await _context.userprofile_tbl.FindAsync(id);

            if (userprofile == null)
            {
                return NotFound();
            }

            return userprofile;
        }

        // PUT: api/userprofile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuserprofile(int id, userprofile userprofile)
        {
            if (id != userprofile.user_id)
            {
                return BadRequest();
            }

            _context.Entry(userprofile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userprofileExists(id))
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

        // POST: api/userprofile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<userprofile>> Postuserprofile(userprofile userprofile)
        {
            _context.userprofile_tbl.Add(userprofile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getuserprofile", new { id = userprofile.user_id }, userprofile);
        }

        // DELETE: api/userprofile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletuserprofile(int id)
        {
            var userprofile = await _context.userprofile_tbl.FindAsync(id);
            if (userprofile == null)
            {
                return NotFound();
            }

            _context.userprofile_tbl.Remove(userprofile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userprofileExists(int id)
        {
            return _context.userprofile_tbl.Any(e => e.user_id == id);
        }

    }
}
