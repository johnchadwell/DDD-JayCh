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
    public class OrderItemsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public OrderItemsController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            System.Diagnostics.Debug.WriteLine("GetOrderItem");
            return await _context.OrderItems.ToListAsync();
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        // GET: api/OrderItemsToProcess
        [HttpGet]
        [Route("~/api/OrderItemsToProcess")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItemsToProcess()
        {
            return await _context.OrderItems
                .Where(o => o.Processed == false)
                .ToListAsync();

        }

        // GET: api/OrderItemsToProcessCount
        [HttpGet]
        [Route("~/api/OrderItemsToProcessCount")]
        public async Task<ActionResult<string>> GetOrderItemsToProcessCount()
        {
            var count = _context.OrderItems
                .Where(o => o.Processed == false)
                .Count().ToString();

            return count;
        }

        //// GET: api/OrderItems/5
        //[HttpGet("{id}")]
        //[Route("~/api/MealOrderItem")]
        //public async Task<ActionResult<MealOrderItem>> GetMealOrderItem(int id)
        //{
        //    var orderItem = await _context.OrderItems.FindAsync(id);

        //    if (orderItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return orderItem;
        //}

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
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

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
        {
            System.Diagnostics.Debug.WriteLine("orderItem.Id" + orderItem.Id);
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItem", new { id = orderItem.Id }, orderItem);
        }
        // POST: api/MealOrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("~/api/MealOrderItems")]
        public async Task<ActionResult<MealOrderItem>> PostMealOrderItem(MealOrderItem orderItem)
        {
            System.Diagnostics.Debug.WriteLine("orderItem.Id" + orderItem.Id);

            if (orderItem.MenuItem != null && orderItem.MenuItem.Id != null)
            {
                MenuItem mi = await _context.MenuItems.FindAsync(orderItem.MenuItem.Id);
                orderItem.MenuItem = mi;

            }
            else
            {
                orderItem.MenuItem = null;
            }


            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItem", new { id = orderItem.Id }, orderItem);
        }
        // POST: api/AlaCarteOrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("~/api/AlaCarteOrderItems")]
        public async Task<ActionResult<AlaCarteOrderItem>> PostAlaCarteOrderItem(AlaCarteOrderItem orderItem)
        {
            System.Diagnostics.Debug.WriteLine("orderItem.Id" + orderItem.Id);

            if (orderItem.MenuItem != null && orderItem.MenuItem.Id != null)
            {
                MenuItem mi = await _context.MenuItems.FindAsync(orderItem.MenuItem.Id);
                orderItem.MenuItem = mi;

            }
            else
            {
                orderItem.MenuItem = null;
            }


            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItem", new { id = orderItem.Id }, orderItem);
        }
        // POST: api/BeverageOrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("~/api/BeverageOrderItems")]
        public async Task<ActionResult<BeverageOrderItem>> PostBeverageOrderItem(BeverageOrderItem orderItem)
        {
            System.Diagnostics.Debug.WriteLine("orderItem.Id" + orderItem.Id);

            if (orderItem.MenuItem != null && orderItem.MenuItem.Id != null)
            {
                MenuItem mi = await _context.MenuItems.FindAsync(orderItem.MenuItem.Id);
                orderItem.MenuItem = mi;

            }
            else
            {
                orderItem.MenuItem = null;
            }


            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItem", new { id = orderItem.Id }, orderItem);
        }
        // POST: api/OptionalOrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("~/api/OptionalOrderItems")]
        public async Task<ActionResult<OptionalOrderItem>> PostOptionalOrderItem(OptionalOrderItem orderItem)
        {
            System.Diagnostics.Debug.WriteLine("orderItem.Id" + orderItem.Id);
            
            if (orderItem.MenuItem != null && orderItem.MenuItem.Id != null)
            {
                orderItem.MenuItem = _context.MenuItems.Attach(new MenuItem { Id = orderItem.MenuItem.Id }).Entity;


                //MenuItem mi = await _context.MenuItems.FindAsync(orderItem.MenuItem.Id);
                //orderItem.MenuItem = mi;

                //if (orderItem.MenuItem.FoodItem != null && orderItem.MenuItem.FoodItem.Id != null)
                //{
                //    FoodItem fi = await _context.FoodItems.FindAsync(orderItem.MenuItem.FoodItem.Id);
                //    orderItem.MenuItem.FoodItem = fi;

                //}
                //else
                //{
                //    orderItem.MenuItem.FoodItem = null;
                //}

                //if (orderItem.OptionalMenuItem.FoodItem != null && orderItem.OptionalMenuItem.FoodItem.Id != null)
                //{
                //    FoodItem fi = await _context.FoodItems.FindAsync(orderItem.OptionalMenuItem.FoodItem.Id);
                //    orderItem.OptionalMenuItem.FoodItem = fi;

                //}
                //else
                //{
                //    orderItem.OptionalMenuItem.FoodItem = null;
                //}

            }
            else
            {
                orderItem.MenuItem = null;
            }

            if (orderItem.Related != null && orderItem.Related.Id != null)
            {

                orderItem.Related = _context.OrderItems.Attach(new OrderItem { Id = orderItem.Related.Id }).Entity;

                //OrderItem mi = await _context.OrderItems.FindAsync(orderItem.Related.Id);
                //orderItem.Related = mi;
            }
            else
            {
                orderItem.Related = null;
            }

            if (orderItem.OptionalMenuItem != null && orderItem.OptionalMenuItem.Id != null)
            {
                orderItem.OptionalMenuItem = _context.OptionalMenuItems.Attach(new OptionalMenuItem { Id = orderItem.OptionalMenuItem.Id }).Entity;
                //orderItem.OptionalMenuItem = _context.OrderItems.Attach(new OptionalOrderItem { Id = orderItem.OptionalMenuItem.Id }).Entity.OptionalMenuItem;

                //OrderItem mi = await _context.OrderItems.FindAsync(orderItem.Related.Id);
                //orderItem.Related = mi;
            }
            else
            {
                orderItem.OptionalMenuItem = null;
            }


            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItem", new { id = orderItem.Id }, orderItem);
        }


        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderItemExists(int id)
        {
            return _context.OrderItems.Any(e => e.Id == id);
        }
    }
}
