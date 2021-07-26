using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class IngredientItem
    {
        public int Id { get; set; }
        public FoodItem FoodItem { get; set; }
        public IngredientItemType IngredientItemType { get; set; }

        public FoodItem ChildFoodItem { get; set; }

        public InventoryItem InventoryItem { get; set; }
        public decimal Amount { get; set; }
        public IngredientUnitType Unit { get; set; }
        public IngredientStateType State { get; set; }
        public decimal InventoryUnitCount { get; set; }
        public decimal Cost { get; set; }

    }

}
