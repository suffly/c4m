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
    public class objectivesController : ControllerBase
    {
        private readonly C4mDBContext _context;

        public objectivesController(C4mDBContext context)
        {
            _context = context;
        }

        // GET: api/objective
        [HttpGet]
        public async Task<ActionResult<IEnumerable<objective>>> Getobjective_tbl()
        {
            return await _context.objective_tbl.ToListAsync();
        }

        // GET: api/objective/5
        [HttpGet("{id}")]
        public async Task<ActionResult<objective>> Getobjective(int id)
        {
            var objective = await _context.objective_tbl.FindAsync(id);

            if (objective == null)
            {
                return NotFound();
            }

            return objective;
        }

        // PUT: api/objective/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putobjective(int id, objective objective)
        {
            if (id != objective.objective_id)
            {
                return BadRequest();
            }

            _context.Entry(objective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!objectiveExists(id))
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

        // POST: api/objective
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<objective>> Postobjective(objective objective)
        {
            _context.objective_tbl.Add(objective);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getobjective", new { id = objective.objective_id }, objective);
        }

        // DELETE: api/objective/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteobjective(int id)
        {
            var objective = await _context.objective_tbl.FindAsync(id);
            if (objective == null)
            {
                return NotFound();
            }

            _context.objective_tbl.Remove(objective);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool objectiveExists(int id)
        {
            return _context.objective_tbl.Any(e => e.objective_id == id);
        }
    }
}
