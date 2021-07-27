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
    public class InventoryConditionTypesController : ControllerBase
    {
        private readonly RecipeContext _context;

        public InventoryConditionTypesController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/InventoryConditionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryConditionType>>> GetInventoryConditionTypes()
        {
            System.Diagnostics.Debug.WriteLine("GetInventoryConditionType");
            return await _context.InventoryConditionType.ToListAsync();
        }

        // GET: api/InventoryConditionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryConditionType>> GetInventoryConditionType(int id)
        {
            var InventoryConditionType = await _context.InventoryConditionType.FindAsync(id);

            if (InventoryConditionType == null)
            {
                return NotFound();
            }

            return InventoryConditionType;
        }

        // PUT: api/InventoryConditionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryConditionType(int id, InventoryConditionType InventoryConditionType)
        {
            if (id != InventoryConditionType.Id)
            {
                return BadRequest();
            }

            _context.Entry(InventoryConditionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryConditionTypeExists(id))
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

        // POST: api/InventoryConditionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryConditionType>> PostInventoryConditionType(InventoryConditionType InventoryConditionType)
        {
            System.Diagnostics.Debug.WriteLine("InventoryConditionType.Id" + InventoryConditionType.Id);
            _context.InventoryConditionType.Add(InventoryConditionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryConditionType", new { id = InventoryConditionType.Id }, InventoryConditionType);
        }

        // DELETE: api/InventoryConditionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryConditionType(int id)
        {
            var InventoryConditionType = await _context.InventoryConditionType.FindAsync(id);
            if (InventoryConditionType == null)
            {
                return NotFound();
            }

            _context.InventoryConditionType.Remove(InventoryConditionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryConditionTypeExists(int id)
        {
            return _context.InventoryConditionType.Any(e => e.Id == id);
        }
    }
}
