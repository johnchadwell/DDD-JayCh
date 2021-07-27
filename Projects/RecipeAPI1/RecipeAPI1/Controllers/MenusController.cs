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
    public class MenusController : ControllerBase
    {
        private readonly RecipeContext _context;

        public MenusController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            System.Diagnostics.Debug.WriteLine("GetMenu");
            return await _context.Menus.ToListAsync();
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }

        [HttpGet]
        [Route("~/api/AllMenuDetails2")]
        public async Task<ActionResult<List<Menu>>> GetAllMenuDetails2()
        {
            //var menuItems = await _context.MenuItems
            //    .Where(n => n.MenuCategoryId == id).ToListAsync();

            var menus = await _context.Menus
                    .Include(b => b.MenuCategories)
                    .ThenInclude(c => c.OptionalMenuItems)
                    .ToListAsync();

            if (menus == null)
            {
                return NotFound();
            }

            return menus;
        }

        [HttpGet]
        [Route("~/api/AllMenuDetails")]
        public async Task<ActionResult<List<Menu>>> AllMenuDetails()
        {
            //var menuItems = await _context.MenuItems
            //    .Where(n => n.MenuCategoryId == id).ToListAsync();

            var menus = await _context.Menus
                    .Include(b => b.MenuCategories)
                    .ThenInclude(c => c.OptionalMenuItems)
                    .ThenInclude(d => d.FoodItem)
                    .Include(b => b.MenuCategories)
                    .ThenInclude(c => c.MenuItems)
                    .ThenInclude(d => d.FoodItem)
                    .Include(b => b.MenuCategories)
                    .ThenInclude(c => c.MenuItems)
                    .ThenInclude(d => d.OptionalMenuItems)
                    .ThenInclude(e => e.FoodItem)
                    .ToListAsync();

            if (menus == null)
            {
                return NotFound();
            }

            return menus;
        }


        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            if (id != menu.Id)
            {
                return BadRequest();
            }

            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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


        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            System.Diagnostics.Debug.WriteLine("menu.Id" + menu.Id);
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenu", new { id = menu.Id }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}
