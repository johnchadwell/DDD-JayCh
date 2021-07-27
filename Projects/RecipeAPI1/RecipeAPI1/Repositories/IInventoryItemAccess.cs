using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IInventoryItemRepository
    {
        int NewInventoryItem(InventoryItem c);
        InventoryItem GetInventoryItem(int id);
        //IEnumerable<InventoryItem> GetAllInventoryItems();
    }
    public class InventoryItemRepository : IInventoryItemRepository
    {
        RecipeContext ctx;
        public InventoryItemRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewInventoryItem(InventoryItem c)
        {
            ctx.InventoryItems.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public InventoryItem GetInventoryItem(int id)
        {
            InventoryItem c = ctx.InventoryItems.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
