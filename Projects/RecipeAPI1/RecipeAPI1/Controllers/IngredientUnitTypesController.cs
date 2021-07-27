using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;


namespace RecipeAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientUnitTypesController : ControllerBase
    {
        private readonly RecipeContext _context;

        public IngredientUnitTypesController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/IngredientUnitTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientUnitType>>> GetIngredientUnitTypes()
        {
            System.Diagnostics.Debug.WriteLine("GetIngredientUnitType");
            return await _context.IngredientUnitType.ToListAsync();
        }

        // GET: api/IngredientUnitTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientUnitType>> GetIngredientUnitType(int id)
        {
            var IngredientUnitType = await _context.IngredientUnitType.FindAsync(id);

            if (IngredientUnitType == null)
            {
                return NotFound();
            }

            return IngredientUnitType;
        }

        // PUT: api/IngredientUnitTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientUnitType(int id, IngredientUnitType IngredientUnitType)
        {
            if (id != IngredientUnitType.Id)
            {
                return BadRequest();
            }

            _context.Entry(IngredientUnitType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientUnitTypeExists(id))
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

        // POST: api/IngredientUnitTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientUnitType>> PostIngredientUnitType(IngredientUnitType IngredientUnitType)
        {
            System.Diagnostics.Debug.WriteLine("IngredientUnitType.Id" + IngredientUnitType.Id);
            _context.IngredientUnitType.Add(IngredientUnitType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientUnitType", new { id = IngredientUnitType.Id }, IngredientUnitType);
        }

        // DELETE: api/IngredientUnitTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientUnitType(int id)
        {
            var IngredientUnitType = await _context.IngredientUnitType.FindAsync(id);
            if (IngredientUnitType == null)
            {
                return NotFound();
            }

            _context.IngredientUnitType.Remove(IngredientUnitType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientUnitTypeExists(int id)
        {
            return _context.IngredientUnitType.Any(e => e.Id == id);
        }
    }
}
