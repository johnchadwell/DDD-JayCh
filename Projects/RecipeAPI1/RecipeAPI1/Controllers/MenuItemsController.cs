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
    public class MenuItemsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public MenuItemsController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/MenuItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {


            System.Diagnostics.Debug.WriteLine("GetMenuItem");
            return await _context.MenuItems.ToListAsync();
        }

        // GET: api/MenuItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {

            //var menuItem = _context.MenuItems
            //          .Where(b => b.Id == id)
            //          .Include(b => b.FoodItem)
            //          .FirstOrDefault();

            var menuItem = _context.MenuItems
                    .Where(b => b.Id == id)
                    .Include(b => b.FoodItem)
                    .ThenInclude(c => c.FoodItemType)
                    .FirstOrDefault();


            //var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return menuItem;
        }

        // GET: api/MenuItemsForMenu/5
        [HttpGet]
        [Route("~/api/MenuItemsForMenu/{id}")]
        public async Task<ActionResult<List<MenuItem>>> GetMenuItemsForMenu(int id)
        {
            //var menuItems = await _context.MenuItems
            //    .Where(n => n.MenuCategoryId == id).ToListAsync();

            var menuItems = await _context.MenuItems
                    .Where(n => n.MenuCategoryId == id)
                    .Include(b => b.FoodItem)
                    .ThenInclude(c => c.FoodItemType)
                    .ToListAsync();

            if (menuItems == null)
            {
                return NotFound();
            }

            return menuItems;
        }



        // PUT: api/MenuItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(int id, MenuItem menuItem)
        {
            if (id != menuItem.Id)
            {
                return BadRequest();
            }

            if (menuItem.FoodItem != null && menuItem.FoodItem.Id != null)
            {
                FoodItem fi = await _context.FoodItems.FindAsync(menuItem.FoodItem.Id);
                menuItem.FoodItem = fi;
            }
            else
            {
                menuItem.FoodItem = null;
            }

            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
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

        // POST: api/MenuItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem(MenuItem menuItem)
        {

            if (menuItem.FoodItem != null && menuItem.FoodItem.Id != null)
            {
                FoodItem fi = await _context.FoodItems.FindAsync(menuItem.FoodItem.Id);
                menuItem.FoodItem = fi;
            }
            else
            {
                menuItem.FoodItem = null;
            }

            System.Diagnostics.Debug.WriteLine("menuItem.Id" + menuItem.Id);
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuItem", new { id = menuItem.Id }, menuItem);
        }

        // DELETE: api/MenuItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuItemExists(int id)
        {
            return _context.MenuItems.Any(e => e.Id == id);
        }
    }
}
