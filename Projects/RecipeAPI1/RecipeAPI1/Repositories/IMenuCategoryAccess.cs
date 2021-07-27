using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IMenuCategoryRepository
    {
        int NewMenuCategory(MenuCategory c);
        MenuCategory GetMenuCategory(int id);
        //IEnumerable<MenuCategory> GetAllMenuCategories();
    }
    public class MenuCategoryRepository : IMenuCategoryRepository
    {
        RecipeContext ctx;
        public MenuCategoryRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewMenuCategory(MenuCategory c)
        {
            ctx.MenuCategories.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public MenuCategory GetMenuCategory(int id)
        {
            MenuCategory c = ctx.MenuCategories.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
