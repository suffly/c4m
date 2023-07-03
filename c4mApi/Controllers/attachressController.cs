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
    public class attachressController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public attachressController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/attachres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<attachres>>> Getattachres_tbl()
        {
            return await _context.attachres_tbl.ToListAsync();
        }

        // GET: api/attachres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<attachres>> Getattachres(int id)
        {
            var attachres = await _context.attachres_tbl.FindAsync(id);

            if (attachres == null)
            {
                return NotFound();
            }

            return attachres;
        }

        // PUT: api/attachres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putattachres(int id, attachres attachres)
        {
            if (id != attachres.attachres_id)
            {
                return BadRequest();
            }

            _context.Entry(attachres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!attachresExists(id))
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

        // POST: api/attachres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<attachres>> Postattachres(attachres attachres)
        {
            _context.attachres_tbl.Add(attachres);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getattachres", new { id = attachres.attachres_id }, attachres);
        }

        // DELETE: api/attachres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteattachres(int id)
        {
            var attachres = await _context.attachres_tbl.FindAsync(id);
            if (attachres == null)
            {
                return NotFound();
            }

            _context.attachres_tbl.Remove(attachres);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool attachresExists(int id)
        {
            return _context.attachres_tbl.Any(e => e.attachres_id == id);
        }

    }
}
