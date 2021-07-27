using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IInventoryUnitTypeRepository
    {
        int NewInventoryUnitType(InventoryUnitType c);
        InventoryUnitType GetInventoryUnitType(int id);
        //IEnumerable<InventoryItem> GetAllInventoryItems();
    }
    public class InventoryUnitTypeRepository : IInventoryUnitTypeRepository
    {
        RecipeContext ctx;
        public InventoryUnitTypeRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewInventoryUnitType(InventoryUnitType c)
        {
            ctx.InventoryUnitType.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public InventoryUnitType GetInventoryUnitType(int id)
        {
            InventoryUnitType c = ctx.InventoryUnitType.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
