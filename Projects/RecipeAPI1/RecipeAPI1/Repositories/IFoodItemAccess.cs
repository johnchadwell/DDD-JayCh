using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IFoodItemRepository
    {
        int NewFoodItem(FoodItem c);
        FoodItem GetFoodItem(int id);
        //IEnumerable<FoodItem> GetAllFoodItems();
    }
    public class FoodItemRepository : IFoodItemRepository
    {
        RecipeContext ctx;
        public FoodItemRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewFoodItem(FoodItem c)
        {
            ctx.FoodItems.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public FoodItem GetFoodItem(int id)
        {
            FoodItem c = ctx.FoodItems.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
