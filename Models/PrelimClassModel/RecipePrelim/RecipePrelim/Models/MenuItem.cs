using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Cost { get; set; }
        public FoodItem FoodItem { get; set; }
        //public MenuItemType MenuItemType { get; set; }
        public int? MenuCategoryId { get; set; }
        public List<OptionalMenuItem> OptionalMenuItems { get; set; }

    }
}
