using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IIngredientUnitTypeRepository
    {
        int NewIngredientUnitType(IngredientUnitType c);
        IngredientUnitType GetIngredientUnitType(int id);
        //IEnumerable<IngredientItem> GetAllIngredientItems();
    }
    public class IngredientUnitTypeRepository : IIngredientUnitTypeRepository
    {
        RecipeContext ctx;
        public IngredientUnitTypeRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewIngredientUnitType(IngredientUnitType c)
        {
            ctx.IngredientUnitType.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public IngredientUnitType GetIngredientUnitType(int id)
        {
            IngredientUnitType c = ctx.IngredientUnitType.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
