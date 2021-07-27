using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IMenuItemRepository
    {
        int NewMenuItem(MenuItem c);
        MenuItem GetMenuItem(int id);
        //IEnumerable<MenuItem> GetAllMenuItems();
    }
    public class MenuItemRepository : IMenuItemRepository
    {
        RecipeContext ctx;
        public MenuItemRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewMenuItem(MenuItem c)
        {
            ctx.MenuItems.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public MenuItem GetMenuItem(int id)
        {
            MenuItem c = ctx.MenuItems.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
