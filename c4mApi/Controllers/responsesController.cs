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
    public class responsesController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public responsesController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/response
        [HttpGet]
        public async Task<ActionResult<IEnumerable<response>>> Getresponse_tbl()
        {
            return await _context.response_tbl.ToListAsync();
        }

        // GET: api/response/5
        [HttpGet("{id}")]
        public async Task<ActionResult<response>> Getresponse(int id)
        {
            var response = await _context.response_tbl.FindAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        // PUT: api/response/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putresponse(int id, response response)
        {
            if (id != response.response_id)
            {
                return BadRequest();
            }

            _context.Entry(response).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!responseExists(id))
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

        // POST: api/response
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<response>> Postresponse(response response)
        {
            _context.response_tbl.Add(response);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getresponse", new { id = response.response_id }, response);
        }

        // DELETE: api/response/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteresponse(int id)
        {
            var response = await _context.response_tbl.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            _context.response_tbl.Remove(response);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool responseExists(int id)
        {
            return _context.response_tbl.Any(e => e.response_id == id);
        }
    }
}
