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
    public class IngredientItemTypesController : ControllerBase
    {
        private readonly RecipeContext _context;

        public IngredientItemTypesController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/IngredientItemTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientItemType>>> GetIngredientItemTypes()
        {
            System.Diagnostics.Debug.WriteLine("GetIngredientItemType");
            return await _context.IngredientItemType.ToListAsync();
        }

        // GET: api/IngredientItemTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientItemType>> GetIngredientItemType(int id)
        {
            var IngredientItemType = await _context.IngredientItemType.FindAsync(id);

            if (IngredientItemType == null)
            {
                return NotFound();
            }

            return IngredientItemType;
        }

        // PUT: api/IngredientItemTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientItemType(int id, IngredientItemType IngredientItemType)
        {
            if (id != IngredientItemType.Id)
            {
                return BadRequest();
            }

            _context.Entry(IngredientItemType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientItemTypeExists(id))
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

        // POST: api/IngredientItemTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientItemType>> PostIngredientItemType(IngredientItemType IngredientItemType)
        {
            System.Diagnostics.Debug.WriteLine("IngredientItemType.Id" + IngredientItemType.Id);
            _context.IngredientItemType.Add(IngredientItemType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientItemType", new { id = IngredientItemType.Id }, IngredientItemType);
        }

        // DELETE: api/IngredientItemTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientItemType(int id)
        {
            var IngredientItemType = await _context.IngredientItemType.FindAsync(id);
            if (IngredientItemType == null)
            {
                return NotFound();
            }

            _context.IngredientItemType.Remove(IngredientItemType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientItemTypeExists(int id)
        {
            return _context.IngredientItemType.Any(e => e.Id == id);
        }
    }
}
