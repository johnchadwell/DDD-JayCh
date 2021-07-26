using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class FoodItem
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public FoodItemType FoodItemType { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public Recipe Recipe { get; set; }
        public decimal Amount { get; set; }
        public FoodUnitType Unit { get; set; }
        public FoodStateType State { get; set; }
        public decimal InventoryUnitCount { get; set; }
        public decimal Cost { get; set; }
    }

}
