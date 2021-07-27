using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IIngredientStateTypeRepository
    {
        int NewIngredientStateType(IngredientStateType c);
        IngredientStateType GetIngredientStateType(int id);
        //IEnumerable<IngredientItem> GetAllIngredientItems();
    }
    public class IngredientStateTypeRepository : IIngredientStateTypeRepository
    {
        RecipeContext ctx;
        public IngredientStateTypeRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewIngredientStateType(IngredientStateType c)
        {
            ctx.IngredientStateType.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public IngredientStateType GetIngredientStateType(int id)
        {
            IngredientStateType c = ctx.IngredientStateType.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
