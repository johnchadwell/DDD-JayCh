using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class MenuCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public int? MenuId { get; set; }
        public List<OptionalMenuItem> OptionalMenuItems { get; set; }
    }
}
