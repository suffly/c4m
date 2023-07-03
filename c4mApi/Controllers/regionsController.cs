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
    public class regionsController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public regionsController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/region
        [HttpGet]
        public async Task<ActionResult<IEnumerable<region>>> Getregion_tbl()
        {
            return await _context.region_tbl.ToListAsync();
        }

        // GET: api/region/5
        [HttpGet("{id}")]
        public async Task<ActionResult<region>> Getregion(int id)
        {
            var region = await _context.region_tbl.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }

        // PUT: api/region/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putregion(int id, region region)
        {
            if (id != region.region_id)
            {
                return BadRequest();
            }

            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!regionExists(id))
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

        // POST: api/region
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<region>> Postregion(region region)
        {
            _context.region_tbl.Add(region);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getregion", new { id = region.region_id }, region);
        }

        // DELETE: api/region/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteregion(int id)
        {
            var region = await _context.region_tbl.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.region_tbl.Remove(region);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool regionExists(int id)
        {
            return _context.region_tbl.Any(e => e.region_id == id);
        }
    }
}
