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
    public class FoodItemTypesController : ControllerBase
    {
        private readonly RecipeContext _context;

        public FoodItemTypesController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/FoodItemTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItemType>>> GetFoodItemTypes()
        {
            return await _context.FoodItemType.ToListAsync();
            //return await _context.FoodItemType
            //    .Where(a => (a.Use.Name == "Recipe" || a.Use.Name == "All")).ToListAsync();
        }
        // GET: api/InventoryItemTypes
        [HttpGet]
        [Route("~/api/InventoryItemTypes")]
        public async Task<ActionResult<IEnumerable<FoodItemType>>> GetInventoryItemTypes()
        {
            return await _context.FoodItemType
                .Where(a => (a.Use.Name == "Inventory" || a.Use.Name == "All")).ToListAsync();
        }

        // GET: api/FoodItemTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItemType>> GetFoodItemTypes(int id)
        {
            var item = await _context.FoodItemType.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }
        // GET: api/FoodItemTypes/5
        [HttpGet("{id}")]
        [Route("~/api/InventoryItemTypes/{id}")]
        public async Task<ActionResult<FoodItemType>> GetInventoryItemTypes(int id)
        {
            var item = await _context.FoodItemType.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }


        // PUT: api/FoodItemTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItemTypes(int id, FoodItemType item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/FoodItemTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodItemType>> PostFoodItemTypes(FoodItemType item)
        {
            System.Diagnostics.Debug.WriteLine("item.Id" + item.Id);

            //if (item.Use != null && item.Use.Id != null)
            //{
            //    TypeClassification use = await _context.TypeClassification.FindAsync(item.Use.Id);
            //    item.Use = use;

            //}
            //else
            //{
            //    item.Use = null;
            //}

            _context.FoodItemType.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostFoodItemType", new { id = item.Id }, item);
        }

        // DELETE: api/FoodItemTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItemTypes(int id)
        {
            var item = await _context.FoodItemType.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.FoodItemType.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.FoodItemType.Any(e => e.Id == id);
        }
    }
}
