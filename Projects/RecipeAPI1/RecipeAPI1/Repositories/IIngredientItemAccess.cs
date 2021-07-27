using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IIngredientItemRepository
    {
        int NewIngredientItem(IngredientItem c);
        IngredientItem GetIngredientItem(int id);
        //IEnumerable<IngredientItem> GetAllIngredientItems();
    }
    public class IngredientItemRepository : IIngredientItemRepository
    {
        RecipeContext ctx;
        public IngredientItemRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewIngredientItem(IngredientItem c)
        {
            ctx.IngredientItems.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public IngredientItem GetIngredientItem(int id)
        {
            IngredientItem c = ctx.IngredientItems.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
