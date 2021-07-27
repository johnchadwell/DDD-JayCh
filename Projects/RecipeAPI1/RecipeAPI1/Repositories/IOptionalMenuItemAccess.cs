using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IOptionalMenuItemRepository
    {
        int NewOptionalMenuItem(OptionalMenuItem c);
        OptionalMenuItem GetOptionalMenuItem(int id);
        //IEnumerable<OptionalMenuItem> GetAllOptionalMenuItems();
    }
    public class OptionalMenuItemRepository : IOptionalMenuItemRepository
    {
        RecipeContext ctx;
        public OptionalMenuItemRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewOptionalMenuItem(OptionalMenuItem c)
        {
            ctx.OptionalMenuItems.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public OptionalMenuItem GetOptionalMenuItem(int id)
        {
            OptionalMenuItem c = ctx.OptionalMenuItems.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
