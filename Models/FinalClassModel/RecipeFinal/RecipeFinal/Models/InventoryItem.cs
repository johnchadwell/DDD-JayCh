using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FoodItemCategory FoodItemCat { get; set; }
        public InventoryConditionType condition { get; set; }
        public InventoryUnitType Unit { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal ReorderThreshold { get; set; }
        public Decimal ReorderQuantity { get; set; }
        public decimal Yield { get; set; }
        public decimal EqvCup { get; set; }
        public decimal EqvPounds { get; set; }
        public decimal EqvUnits { get; set; }



}



}
