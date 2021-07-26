using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class FoodItemCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryUse Use { get; set; }
    }
}


