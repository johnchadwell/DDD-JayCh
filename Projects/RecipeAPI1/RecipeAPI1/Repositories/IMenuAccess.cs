using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IMenuRepository
    {
        int NewMenu(Menu c);
        Menu GetMenu(int id);
        //IEnumerable<Menu> GetAllMenus();
    }
    public class MenuRepository : IMenuRepository
    {
        RecipeContext ctx;
        public MenuRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewMenu(Menu c)
        {
            ctx.Menus.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public Menu GetMenu(int id)
        {
            Menu c = ctx.Menus.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
