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
    public class FoodItemsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public FoodItemsController(RecipeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
        {
            //System.Diagnostics.Debug.WriteLine("GetFoodItem");
            return await _context.FoodItems
                                .Include(b => b.FoodItemType)
                                .ToListAsync();
        }
        // GET: api/FoodItemsByType/5
        [HttpGet]
        [Route("~/api/FoodItemsByType/{id}")]
        public async Task<ActionResult<List<FoodItem>>> GetFoodItemsByType(int id)
        {

            var items = await _context.FoodItems
                            .Include(b => b.FoodItemType)
                            .Where(c => c.FoodItemType.Id == id)
                            .ToListAsync();


            return items;
        }

        // GET: api/FoodItemAndIngredients/5
        [Route("~/api/FoodItemAndIngredients/{id}")]
        public async Task<ActionResult<FoodItem>> FoodItemAndIngredients(int id)
        {
            //var foodItem = await _context.FoodItems.FindAsync(id);
            //var foodItem = _context.FoodItems
            //          .Where(b => b.Id == id)
            //          .Include(b => b.IngredientItem)
            //          .FirstOrDefault();

            var foodItem = _context.FoodItems
                            .Where(b => b.Id == id)
                            .Include(b => b.IngredientItem)
                            .ThenInclude(c => c.InventoryItem)
                            .ThenInclude(d => d.condition)
                            .Include(b => b.IngredientItem)
                            .ThenInclude(c => c.InventoryItem)
                            .ThenInclude(d => d.Unit)
                            .Include(b => b.IngredientItem)
                            .ThenInclude(c => c.Unit)
                            .Include(b => b.IngredientItem)
                            .ThenInclude(c => c.State)
                            .Include(b => b.FoodItemType)
                            .FirstOrDefault();


            return foodItem;
        }

        // GET: api/FoodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItem>> GetFoodItems(int id)
        {
            var foodItem = _context.FoodItems
                            .Where(b => b.Id == id)
                            .Include(b => b.FoodItemType)
                            .FirstOrDefault();
            if (foodItem == null)
            {
                return NotFound();
            }

            return foodItem;
        }


        // PUT: api/FoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItem(int id, FoodItem foodItem)
        {
            if (id != foodItem.Id)
            {
                return BadRequest();
            }
            if (foodItem.FoodItemType != null && foodItem.FoodItemType.Id != null)
            {
                FoodItemType fit = await _context.FoodItemType.FindAsync(foodItem.FoodItemType.Id);
                foodItem.FoodItemType = fit;
            }
            else
            {
                foodItem.FoodItemType = null;
            }

            _context.Entry(foodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemExists(id))
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

        // POST: api/FoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodItem>> PostFoodItem(FoodItem foodItem)
        {
            if (foodItem.FoodItemType != null && foodItem.FoodItemType.Id != null)
            {
                FoodItemType fit = await _context.FoodItemType.FindAsync(foodItem.FoodItemType.Id);
                foodItem.FoodItemType = fit;
            }
            else
            {
                foodItem.FoodItemType = null;
            }

            _context.FoodItems.Add(foodItem);
            await _context.SaveChangesAsync();
            System.Diagnostics.Debug.WriteLine("FoodItem.Id" + foodItem.Id);
            return CreatedAtAction("GetFoodItems", new { id = foodItem.Id }, foodItem);
        }

        //[HttpPost]
        //[Route("~/api/BeverageFoodItem")]
        //public async Task<ActionResult<BeverageFoodItem>> PostBeverageFoodItem(BeverageFoodItem foodItem)
        //{
        //    _context.FoodItems.Add(foodItem);
        //    await _context.SaveChangesAsync();
        //    System.Diagnostics.Debug.WriteLine("FoodItem.Id" + foodItem.Id);
        //    return Ok(foodItem);
        //    //return CreatedAtAction("GetFoodItem", new { id = foodItem.Id }, foodItem);
        //}
        //[HttpPost]
        //[Route("~/api/AlaCarteFoodItem")]
        //public async Task<ActionResult<AlaCarteFoodItem>> PostAlaCarteFoodItem(AlaCarteFoodItem foodItem)
        //{
        //    _context.FoodItems.Add(foodItem);
        //    await _context.SaveChangesAsync();
        //    System.Diagnostics.Debug.WriteLine("FoodItem.Id" + foodItem.Id);
        //    return Ok(foodItem);
        //    //return CreatedAtAction("GetFoodItem", new { id = foodItem.Id }, foodItem);
        //}
        //[HttpPost]
        //[Route("~/api/OptionalFoodItem")]
        //public async Task<ActionResult<BeverageFoodItem>> PostOptionalFoodItem(OptionalFoodItem foodItem)
        //{
        //    _context.FoodItems.Add(foodItem);
        //    await _context.SaveChangesAsync();
        //    System.Diagnostics.Debug.WriteLine("FoodItem.Id" + foodItem.Id);
        //    return Ok(foodItem);
        //    //return CreatedAtAction("GetFoodItem", new { id = foodItem.Id }, foodItem);
        //}

        // DELETE: api/FoodItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItem(int id)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodItemExists(int id)
        {
            return _context.FoodItems.Any(e => e.Id == id);
        }

        //// GET: api/FoodItems
        //[HttpGet]
        //public async Task<ActionResult> GetFoodItemsPartial()
        //{
        //    //System.Diagnostics.Debug.WriteLine("GetFoodItem");
        //    List<FoodItem> items = await _context.FoodItems.ToListAsync();
        //    return PartialView(items);
        //}
        //private ActionResult PartialView(List<FoodItem> items)
        //{
        //    return Partial("Index1", items);
        //}

        //// GET: api/GetFoodItemTypes
        //[HttpGet]
        //[Route("~/api/FoodItemTypes")]
        //public async Task<ActionResult<IEnumerable<FoodItemType>>> FoodItemTypes()
        //{
        //    return await _context.FoodItemType.ToListAsync();
        //}

        //// GET: api/FoodItems
        //[HttpGet]
        //[Route("~/api/FoodItems/Type/{type}")]
        //public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems(string type)
        //{
        //    //System.Diagnostics.Debug.WriteLine("GetFoodItem");
        //    if (type.ToLower().Equals("alacarte"))
        //    {
        //        List<AlaCarteFoodItem> items = await _context.FoodItems.OfType<AlaCarteFoodItem>().ToListAsync();
        //        return new JsonResult(items);
        //    }
        //    else if (type.ToLower().Equals("beverage"))
        //    {
        //        List<BeverageFoodItem> items = await _context.FoodItems.OfType<BeverageFoodItem>().ToListAsync();
        //        return new JsonResult(items);
        //    }
        //    else if (type.ToLower().Equals("optional"))
        //    {
        //        List<OptionalFoodItem> items = await _context.FoodItems.OfType<OptionalFoodItem>().ToListAsync();
        //        return new JsonResult(items);
        //    }
        //    else
        //    {
        //        return await _context.FoodItems.ToListAsync();
        //    }
        //}
        //// GET: api/FoodItems
        //[HttpGet]
        //[Route("~/api/AlaCarteFoodItems")]
        //public async Task<ActionResult<IEnumerable<AlaCarteFoodItem>>> GetAlaCarteFoodItems()
        //{
        //    //System.Diagnostics.Debug.WriteLine("GetFoodItem");
        //    return await _context.AlaCarteFoodItems.ToListAsync();
        //}
        //// GET: api/FoodItems
        //[HttpGet]
        //[Route("~/api/BeverageFoodItems")]
        //public async Task<ActionResult<IEnumerable<BeverageFoodItem>>> GetBeverageFoodItems()
        //{
        //    //System.Diagnostics.Debug.WriteLine("GetFoodItem");
        //    return await _context.BeverageFoodItems.ToListAsync();
        //}
        //[HttpGet]
        //[Route("~/api/OptionalFoodItems")]
        //public async Task<ActionResult<IEnumerable<OptionalFoodItem>>> GetOptionalFoodItems()
        //{
        //    //System.Diagnostics.Debug.WriteLine("GetFoodItem");
        //    return await _context.OptionalFoodItems.ToListAsync();
        //}

    }
}
