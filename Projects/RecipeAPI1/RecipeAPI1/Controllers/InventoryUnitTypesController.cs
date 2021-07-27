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
    public class InventoryUnitTypesController : ControllerBase
    {
        private readonly RecipeContext _context;

        public InventoryUnitTypesController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/InventoryUnitTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryUnitType>>> GetInventoryUnitTypes()
        {
            System.Diagnostics.Debug.WriteLine("GetInventoryUnitType");
            return await _context.InventoryUnitType.ToListAsync();
        }

        // GET: api/InventoryUnitTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryUnitType>> GetInventoryUnitType(int id)
        {
            var InventoryUnitType = await _context.InventoryUnitType.FindAsync(id);

            if (InventoryUnitType == null)
            {
                return NotFound();
            }

            return InventoryUnitType;
        }

        // PUT: api/InventoryUnitTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryUnitType(int id, InventoryUnitType InventoryUnitType)
        {
            if (id != InventoryUnitType.Id)
            {
                return BadRequest();
            }

            _context.Entry(InventoryUnitType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryUnitTypeExists(id))
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

        // POST: api/InventoryUnitTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryUnitType>> PostInventoryUnitType(InventoryUnitType InventoryUnitType)
        {
            System.Diagnostics.Debug.WriteLine("InventoryUnitType.Id" + InventoryUnitType.Id);
            _context.InventoryUnitType.Add(InventoryUnitType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryUnitType", new { id = InventoryUnitType.Id }, InventoryUnitType);
        }

        // DELETE: api/InventoryUnitTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryUnitType(int id)
        {
            var InventoryUnitType = await _context.InventoryUnitType.FindAsync(id);
            if (InventoryUnitType == null)
            {
                return NotFound();
            }

            _context.InventoryUnitType.Remove(InventoryUnitType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryUnitTypeExists(int id)
        {
            return _context.InventoryUnitType.Any(e => e.Id == id);
        }
    }
}
