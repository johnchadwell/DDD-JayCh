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
    public class MenuCategoriesController : ControllerBase
    {
        private readonly RecipeContext _context;

        public MenuCategoriesController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/MenuCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuCategory>>> GetMenuCategories()
        {
            System.Diagnostics.Debug.WriteLine("GetMenuCategory");
            return await _context.MenuCategories.ToListAsync();
        }

        // GET: api/MenuCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuCategory>> GetMenuCategory(int id)
        {
            var menuCategory = await _context.MenuCategories.FindAsync(id);

            if (menuCategory == null)
            {
                return NotFound();
            }

            return menuCategory;
        }

        // GET: api/CategoriesForMenu/5
        [HttpGet]
        [Route("~/api/CategoriesForMenu/{id}")]
        public async Task<ActionResult<IEnumerable<MenuCategory>>> GetCategoriesForMenu(int id)
        {
            var menuCategories = await _context.MenuCategories
                .Where(n => n.MenuId == id).ToListAsync();
            //var menuCategory = await _context.MenuCategories.FindAsync(id);

            if (menuCategories == null)
            {
                return NotFound();
            }

            return menuCategories;
        }


        // PUT: api/MenuCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuCategory(int id, MenuCategory menuCategory)
        {
            if (id != menuCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuCategoryExists(id))
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

        // POST: api/MenuCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuCategory>> PostMenuCategory(MenuCategory menuCategory)
        {

            _context.MenuCategories.Add(menuCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuCategory", new { id = menuCategory.Id }, menuCategory);
        }

        // DELETE: api/MenuCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuCategory(int id)
        {
            var menuCategory = await _context.MenuCategories.FindAsync(id);
            if (menuCategory == null)
            {
                return NotFound();
            }

            _context.MenuCategories.Remove(menuCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuCategoryExists(int id)
        {
            return _context.MenuCategories.Any(e => e.Id == id);
        }
    }
}
