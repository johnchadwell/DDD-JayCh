using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;
using RecipeClassLibrary.DTO;
using Microsoft.Data.SqlClient;

namespace RecipeAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientItemsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public IngredientItemsController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/IngredientItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientItem>>> GetIngredientItems()
        {
            System.Diagnostics.Debug.WriteLine("GetIngredientItem");
            return await _context.IngredientItems.ToListAsync();
        }

        // GET: api/IngredientItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientItem>> GetIngredientItems(int id)
        {
            var ingredientItem = _context.IngredientItems
                      .Where(b => b.Id == id)
                      .Include(b => b.Unit)
                      .Include(b => b.State)
                      .Include(b => b.InventoryItem)
                      .ThenInclude(c => c.condition)
                      .Include(b => b.InventoryItem)
                      .ThenInclude(c => c.Unit)
                      .FirstOrDefault();


            if (ingredientItem == null)
            {
                return NotFound();
            }

            return ingredientItem;
        }

        // GET: api/OptionsForMenuCategory/5
        [HttpGet]
        [Route("~/api/IngredientItemsByFoodItem/{id}")]
        public async Task<ActionResult<IEnumerable<IngredientItem>>> GetIngredientItemsByFoodItem(int id)
        {
            //var optionalItems = await _context.OptionalMenuItems
            //    .Where(n => n.MenuCategoryId == id).ToListAsync();
            ////var menuCategory = await _context.MenuCategories.FindAsync(id);

            var items = await _context.IngredientItems
                .Where(b => b.FoodItemId == id)
                .Include(b => b.IngredientItemType)
                .Include(b => b.InventoryItem)
                .ThenInclude(c => c.Unit)
                .Include(b => b.State)
                .Include(b => b.Unit)
                .Include(b => b.IngredientItemType)

                .ToListAsync();

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }



        // PUT: api/IngredientItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientItem(int id, IngredientItem ingredientItem)
        {
            if (id != ingredientItem.Id)
            {
                return BadRequest();
            }

            System.Diagnostics.Debug.WriteLine("ingredientItem.Id" + ingredientItem.Id);

            if (ingredientItem.InventoryItem != null && ingredientItem.InventoryItem.Id != null)
            {
                InventoryItem iv = await _context.InventoryItems.FindAsync(ingredientItem.InventoryItem.Id);
                ingredientItem.InventoryItem = iv;
            }
            else
            {
                ingredientItem.InventoryItem = null;
            }

            if (ingredientItem.IngredientItemType != null && ingredientItem.IngredientItemType.Id != null)
            {
                IngredientItemType ing = await _context.IngredientItemType.FindAsync(ingredientItem.IngredientItemType.Id);
                ingredientItem.IngredientItemType = ing;
            }
            else
            {
                ingredientItem.IngredientItemType = null;
            }

            if (ingredientItem.State != null && ingredientItem.State.Id != null)
            {
                IngredientStateType ist = await _context.IngredientStateType.FindAsync(ingredientItem.State.Id);
                ingredientItem.State = ist;
            }
            else
            {
                ingredientItem.State = null;
            }

            if (ingredientItem.Unit != null && ingredientItem.Unit.Id != null)
            {
                IngredientUnitType iut = await _context.IngredientUnitType.FindAsync(ingredientItem.Unit.Id);
                ingredientItem.Unit = iut;
            }
            else
            {
                ingredientItem.Unit = null;
            }


            _context.Entry(ingredientItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientItemExists(id))
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

        // POST: api/IngredientItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientItem>> PostIngredientItem(IngredientItem ingredientItem)
        {
            System.Diagnostics.Debug.WriteLine("ingredientItem.Id" + ingredientItem.Id);

            if (ingredientItem.InventoryItem != null && ingredientItem.InventoryItem.Id != null)
            {
                InventoryItem iv = await _context.InventoryItems.FindAsync(ingredientItem.InventoryItem.Id);
                ingredientItem.InventoryItem = iv;
            }
            else
            {
                ingredientItem.InventoryItem = null;
            }

            if (ingredientItem.IngredientItemType != null && ingredientItem.IngredientItemType.Id != null)
            {
                IngredientItemType ing = await _context.IngredientItemType.FindAsync(ingredientItem.IngredientItemType.Id);
                ingredientItem.IngredientItemType = ing;
            }
            else
            {
                ingredientItem.IngredientItemType = null;
            }

            if (ingredientItem.State != null && ingredientItem.State.Id != null)
            {
                IngredientStateType ist = await _context.IngredientStateType.FindAsync(ingredientItem.State.Id);
                ingredientItem.State = ist;
            }
            else
            {
                ingredientItem.State = null;
            }

            if (ingredientItem.Unit != null && ingredientItem.Unit.Id != null)
            {
                IngredientUnitType iut = await _context.IngredientUnitType.FindAsync(ingredientItem.Unit.Id);
                ingredientItem.Unit = iut;
            }
            else
            {
                ingredientItem.Unit = null;
            }


            _context.IngredientItems.Add(ingredientItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientItems", new { id = ingredientItem.Id }, ingredientItem);
        }
        [HttpPost]
        [Route("~/api/PostIngredientItems2")]
        public async Task<ActionResult<IngredientItem>> PostIngredientItem2(IngredientItem ingredientItem)
        {


            System.Diagnostics.Debug.WriteLine("ingredientItem.Id" + ingredientItem.Id);
            _context.IngredientItems.Add(ingredientItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientItems", new { id = ingredientItem.Id }, ingredientItem);
        }
        [HttpPost]
        [Route("~/api/IngredientItemsDTO")]
        public async Task<ActionResult> PostIngredientItemsDTO(IngredientItemDTO inventoryItemDTO)
        {

            try
            {

                var commandText = "INSERT INTO[dbo].[IngredientItems] " +
                    "([FoodItemId]," +
                    "[InventoryItemId]," +
                    "[Amount]," +
                    "[InventoryUnitCount]," +
                    "[Cost]" +
                    ",[StateId]" +
                    ",[UnitId])" +
                "VALUES" +
                    "(@FoodItemId" +
                    ",@InventoryId" +
                    ",@Amount" +
                    ",@InventoryUnitCount" +
                    ",@Cost" +
                    ",@StateId" +
                    ",@UnitId)";

                var name0 = new SqlParameter("@FoodItemId", inventoryItemDTO.FoodItemId);
                var name1 = new SqlParameter("@InventoryId", inventoryItemDTO.InventoryId);
                var name2 = new SqlParameter("@Amount", inventoryItemDTO.Amount);
                var name3 = new SqlParameter("@InventoryUnitCount", inventoryItemDTO.InventoryUnitCount);
                var name4 = new SqlParameter("@Cost", inventoryItemDTO.Cost);
                var name5 = new SqlParameter("@StateId", inventoryItemDTO.StateId);
                var name6 = new SqlParameter("@UnitId", inventoryItemDTO.UnitId);
                _context.Database.ExecuteSqlRaw(commandText, name0, name1, name2, name3, name4, name5, name6);

            } catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + e.Message);
                return BadRequest(e.Message.ToString());
            }
            //return CreatedAtAction("GetIngredientItem", new { id = inventoryItemDTO.Id }, inventoryItemDTO);
            return Ok();
        }


        [HttpPost]
        [Route("~/api/IngredientItemsDTO2")]
        //public async Task<ActionResult<InventoryItem>> PostInventoryItem(IngredientItemDTO inventoryItemDTO)
        //public async Task<ActionResult> PostInventoryItem()
        public async Task<ActionResult> PostIngredientItemsDTO2()
        {

            try
            {

                var commandText = "INSERT INTO[dbo].[IngredientItems] " +
                    "([FoodItemId]," +
                    "[InventoryItemId]," +
                    "[Amount]," +
                    "[InventoryUnitCount]," +
                    "[Cost]" +
                    ",[StateId]" +
                    ",[UnitId])" +
                "VALUES" +
                    "(1" +
                    ",4" +
                    ",1.0" +
                    ",3" +
                    ",3.0" +
                    ",3" +
                    ",3)";
                System.Diagnostics.Debug.WriteLine("commandText" + commandText);
                _context.Database.ExecuteSqlRaw(commandText);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + e.Message);
                return BadRequest(e.Message.ToString());
            }
            //return CreatedAtAction("GetIngredientItem", new { id = inventoryItemDTO.Id }, inventoryItemDTO);
            return Ok();
        }

        // DELETE: api/IngredientItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientItem(int id)
        {
            var ingredientItem = await _context.IngredientItems.FindAsync(id);
            if (ingredientItem == null)
            {
                return NotFound();
            }

            _context.IngredientItems.Remove(ingredientItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientItemExists(int id)
        {
            return _context.IngredientItems.Any(e => e.Id == id);
        }
    }
}
