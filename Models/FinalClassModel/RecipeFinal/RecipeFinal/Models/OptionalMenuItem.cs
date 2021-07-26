using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class OptionalMenuItem
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public double Cost { get; set; }
        public FoodItem FoodItem { get; set; }
        public int? MenuCategoryId { get; set; }
        public int? MenuItemId { get; set; }
    }
}
