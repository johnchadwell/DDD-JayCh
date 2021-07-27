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
    public class IngredientStateTypesController : ControllerBase
    {
        private readonly RecipeContext _context;

        public IngredientStateTypesController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/IngredientStateTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientStateType>>> GetIngredientStateTypes()
        {
            System.Diagnostics.Debug.WriteLine("GetIngredientStateType");
            return await _context.IngredientStateType.ToListAsync();
        }

        // GET: api/IngredientStateTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientStateType>> GetIngredientStateType(int id)
        {
            var IngredientStateType = await _context.IngredientStateType.FindAsync(id);

            if (IngredientStateType == null)
            {
                return NotFound();
            }

            return IngredientStateType;
        }

        // PUT: api/IngredientStateTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientStateType(int id, IngredientStateType IngredientStateType)
        {
            if (id != IngredientStateType.Id)
            {
                return BadRequest();
            }

            _context.Entry(IngredientStateType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientStateTypeExists(id))
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

        // POST: api/IngredientStateTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientStateType>> PostIngredientStateType(IngredientStateType IngredientStateType)
        {
            System.Diagnostics.Debug.WriteLine("IngredientStateType.Id" + IngredientStateType.Id);
            _context.IngredientStateType.Add(IngredientStateType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientStateType", new { id = IngredientStateType.Id }, IngredientStateType);
        }

        // DELETE: api/IngredientStateTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientStateType(int id)
        {
            var IngredientStateType = await _context.IngredientStateType.FindAsync(id);
            if (IngredientStateType == null)
            {
                return NotFound();
            }

            _context.IngredientStateType.Remove(IngredientStateType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientStateTypeExists(int id)
        {
            return _context.IngredientStateType.Any(e => e.Id == id);
        }
    }
}
