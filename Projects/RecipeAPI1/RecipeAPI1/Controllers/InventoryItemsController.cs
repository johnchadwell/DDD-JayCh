using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI1.Models;
using RecipeClassLibrary.DTO;
using RecipeClassLibrary.Models;


namespace RecipeAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public InventoryItemsController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/InventoryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventoryItems()
        {
            System.Diagnostics.Debug.WriteLine("GetInventoryItem");

            return await _context.InventoryItems.ToListAsync();
        }
        [HttpGet]
        [Route("~/api/GetInventoryItems2")]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventoryItems2()
        {
            System.Diagnostics.Debug.WriteLine("GetInventoryItem");
            return await _context.InventoryItems.Include(e => e.condition).ToListAsync();
        }
        [HttpGet]
        [Route("~/api/DDInventoryItems")]
        public async Task<IActionResult> GetDDInventoryItems()
        {
            System.Diagnostics.Debug.WriteLine("GetInventoryItem");

            var l = await _context.InventoryItems.Join(_context.InventoryConditionType,
                i => i.condition.Id,
                c => c.Id,
                (i, c) =>
                new
                {
                    Name = i.Name,
                    Id = i.Id,
                    ConditionId = c.Id,
                    Condition = c.Name,
                }
            ).ToListAsync();
            return Ok(l);
        }

        // GET: api/InventoryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItem>> GetInventoryItem(int id)
        {
            var inventoryItem = await _context.InventoryItems.FindAsync     (id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return inventoryItem;
        }
        // GET: api/GetInventoryItem/5
        [HttpGet]
        [Route("~/api/GetInventoryItem/{id}")]
        public async Task<ActionResult<InventoryItem>> GetInventoryItems(int id)
        {
            System.Diagnostics.Debug.WriteLine("GetInventoryItem");
            return await _context.InventoryItems
                .Include(a => a.condition)
                .Include(a => a.Unit)
                .FirstOrDefaultAsync();

        }

        [HttpGet]
        [Route("~/api/InventoryItemsByFoodType/{id}")]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventoryItemsByFoodType(int id)
        {
            //var optionalItems = await _context.OptionalMenuItems
            //    .Where(n => n.MenuCategoryId == id).ToListAsync();
            ////var menuCategory = await _context.MenuCategories.FindAsync(id);

            var items = await _context.InventoryItems
                .Where(b => b.FoodItemType.Id == id)
                .Include(b => b.FoodItemType)
                .Include(b => b.condition)
                .Include(b => b.Unit)
                .ToListAsync();

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        // PUT: api/InventoryItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryItem(int id, InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
            {
                return BadRequest();
            }

            if (inventoryItem.FoodItemType != null && inventoryItem.FoodItemType.Id != null)
            {
                FoodItemType fit = await _context.FoodItemType.FindAsync(inventoryItem.FoodItemType.Id);
                inventoryItem.FoodItemType = fit;

            }
            else
            {
                inventoryItem.FoodItemType = null;
            }

            if (inventoryItem.Unit != null && inventoryItem.Unit.Id != null)
            {
                InventoryUnitType iut = await _context.InventoryUnitType.FindAsync(inventoryItem.Unit.Id);
                inventoryItem.Unit = iut;

            }
            else
            {
                inventoryItem.Unit = null;
            }

            if (inventoryItem.condition != null && inventoryItem.condition.Id != null)
            {
                InventoryConditionType ict = await _context.InventoryConditionType.FindAsync(inventoryItem.condition.Id);
                inventoryItem.condition = ict;
            }
            else
            {
                inventoryItem.condition = null;
            }


            _context.Entry(inventoryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryItemExists(id))
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

        // POST: api/InventoryItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryItem>> PostInventoryItem(InventoryItem inventoryItem)
        {
            System.Diagnostics.Debug.WriteLine("inventoryItem.Id" + inventoryItem.Id);

            if (inventoryItem.FoodItemType != null && inventoryItem.FoodItemType.Id != null)
            {
                FoodItemType fit = await _context.FoodItemType.FindAsync(inventoryItem.FoodItemType.Id);
                inventoryItem.FoodItemType = fit;

            }
            else
            {
                inventoryItem.FoodItemType = null;
            }

            if (inventoryItem.Unit!=null && inventoryItem.Unit.Id != null)
            {
                InventoryUnitType iut = await _context.InventoryUnitType.FindAsync(inventoryItem.Unit.Id);
                inventoryItem.Unit = iut;

            } else
            {
                inventoryItem.Unit = null;
            }

            if (inventoryItem.condition != null && inventoryItem.condition.Id != null)
            {
                InventoryConditionType ict = await _context.InventoryConditionType.FindAsync(inventoryItem.condition.Id);
                inventoryItem.condition = ict;
            }
            else
            {
                inventoryItem.condition = null;
            }

            _context.InventoryItems.Add(inventoryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.Id }, inventoryItem);
        }

        // DELETE: api/InventoryItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItem(int id)
        {
            var inventoryItem = await _context.InventoryItems.FindAsync(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            _context.InventoryItems.Remove(inventoryItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryItemExists(int id)
        {
            return _context.InventoryItems.Any(e => e.Id == id);
        }
    }
}
