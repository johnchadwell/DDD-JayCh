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
    public class OptionalMenuItemsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public OptionalMenuItemsController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/OptionalMenuItems
        [HttpGet]
        public async Task<ActionResult<List<OptionalMenuItem>>> GetOptionalMenuItems()
        {
            System.Diagnostics.Debug.WriteLine("GetOptionalMenuItem");
            var items = await _context.OptionalMenuItems
                .Include(b => b.FoodItem)
                .ThenInclude(c => c.FoodItemType)
                .ToListAsync();

            //public async Task<ActionResult<IEnumerable<OptionalMenuItem>>> GetOptionalMenuItems()
            //return await _context.OptionalMenuItems.ToListAsync();
            return items;
        }

        // GET: api/OptionalMenuItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OptionalMenuItem>> GetOptionalMenuItem(int id)
        {
            var optionalMenuItem = await _context.OptionalMenuItems.FindAsync(id);

            if (optionalMenuItem == null)
            {
                return NotFound();
            }

            return optionalMenuItem;
        }

        // GET: api/OptionsForMenuItem/5
        [HttpGet]
        [Route("~/api/OptionsForMenuItem/{id}")]
        public async Task<ActionResult<IEnumerable<OptionalMenuItem>>> GetOptionsForMenuItem(int id)
        {
            //var optionalItems = await _context.OptionalMenuItems
            //    .Where(n => n.MenuItemId == id).ToListAsync();
            ////var menuCategory = await _context.MenuCategories.FindAsync(id);

            var items = await _context.OptionalMenuItems
                .Where(n => n.MenuItemId == id)
                .Include(b => b.FoodItem)
                .ThenInclude(c => c.FoodItemType)
                .ToListAsync();


            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        // GET: api/OptionsForMenuCategory/5
        [HttpGet]
        [Route("~/api/OptionsForMenuCategory/{id}")]
        public async Task<ActionResult<IEnumerable<OptionalMenuItem>>> GetOptionsForMenuCategory(int id)
        {
            //var optionalItems = await _context.OptionalMenuItems
            //    .Where(n => n.MenuCategoryId == id).ToListAsync();
            ////var menuCategory = await _context.MenuCategories.FindAsync(id);

            var items = await _context.OptionalMenuItems
                .Where(n => n.MenuCategoryId == id)
                .Include(b => b.FoodItem)
                .ThenInclude(c => c.FoodItemType)
                .ToListAsync();

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }


        // PUT: api/OptionalMenuItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOptionalMenuItems(int id, OptionalMenuItem optionalMenuItem)
        {
            if (id != optionalMenuItem.Id)
            {
                return BadRequest();
            }
            if (optionalMenuItem.FoodItem != null && optionalMenuItem.FoodItem.Id != null)
            {
                FoodItem fi = await _context.FoodItems.FindAsync(optionalMenuItem.FoodItem.Id);
                optionalMenuItem.FoodItem = fi;
            }
            else
            {
                optionalMenuItem.FoodItem = null;
            }

            _context.Entry(optionalMenuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionalMenuItemExists(id))
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

        // POST: api/OptionalMenuItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OptionalMenuItem>> PostOptionalMenuItems(OptionalMenuItem optionalMenuItem)
        {
            if (optionalMenuItem.FoodItem != null && optionalMenuItem.FoodItem.Id != null)
            {
                FoodItem fi = await _context.FoodItems.FindAsync(optionalMenuItem.FoodItem.Id);
                optionalMenuItem.FoodItem = fi;
            }
            else
            {
                optionalMenuItem.FoodItem = null;
            }



            System.Diagnostics.Debug.WriteLine("optionalMenuItem.Id" + optionalMenuItem.Id);
            _context.OptionalMenuItems.Add(optionalMenuItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOptionalMenuItem", new { id = optionalMenuItem.Id }, optionalMenuItem);
        }

        // DELETE: api/OptionalMenuItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOptionalMenuItems(int id)
        {
            var optionalMenuItem = await _context.OptionalMenuItems.FindAsync(id);
            if (optionalMenuItem == null)
            {
                return NotFound();
            }

            _context.OptionalMenuItems.Remove(optionalMenuItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OptionalMenuItemExists(int id)
        {
            return _context.OptionalMenuItems.Any(e => e.Id == id);
        }
    }
}
