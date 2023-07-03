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
    public class provincesController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public provincesController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/province
        [HttpGet]
        public async Task<ActionResult<IEnumerable<province>>> Getprovince_tbl()
        {
            return await _context.province_tbl.ToListAsync();
        }

        // GET: api/province/5
        [HttpGet("{id}")]
        public async Task<ActionResult<province>> Getprovince(int id)
        {
            var province = await _context.province_tbl.FindAsync(id);

            if (province == null)
            {
                return NotFound();
            }

            return province;
        }

        // PUT: api/province/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putprovince(int id, province province)
        {
            if (id != province.province_id)
            {
                return BadRequest();
            }

            _context.Entry(province).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!provinceExists(id))
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

        // POST: api/province
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<province>> Postprovince(province province)
        {
            _context.province_tbl.Add(province);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getprovince", new { id = province.province_id }, province);
        }

        // DELETE: api/province/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteprovince(int id)
        {
            var province = await _context.province_tbl.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }

            _context.province_tbl.Remove(province);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool provinceExists(int id)
        {
            return _context.province_tbl.Any(e => e.province_id == id);
        }
    }
}
