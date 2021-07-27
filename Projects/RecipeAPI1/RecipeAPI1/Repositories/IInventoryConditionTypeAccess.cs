using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IInventoryConditionTypeRepository
    {
        int NewInventoryConditionType(InventoryConditionType c);
        InventoryConditionType GetInventoryConditionType(int id);
        //IEnumerable<InventoryItem> GetAllInventoryItems();
    }
    public class InventoryConditionTypeRepository : IInventoryConditionTypeRepository
    {
        RecipeContext ctx;
        public InventoryConditionTypeRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewInventoryConditionType(InventoryConditionType c)
        {
            ctx.InventoryConditionType.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public InventoryConditionType GetInventoryConditionType(int id)
        {
            InventoryConditionType c = ctx.InventoryConditionType.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
