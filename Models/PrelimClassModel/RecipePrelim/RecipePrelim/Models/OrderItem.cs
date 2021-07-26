using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }
        public MenuItem MenuItem { get; set; }
        public OptionalMenuItem OptionalMenuItem { get; set; }

    }
    public class AlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }

    public class OptionalOrderItem : OrderItem, IAdjustInventory
    {
        public OrderItem Related { get; set; }
        public bool AddToCost { get; set; }
        public DeltaQuantity Quantity { get; set; }

        // update the ingredient in inventory
        public void AdjustInventoryCount()
        {
        }
    }

    public class BeverageOrderItem : OrderItem, IAdjustInventory
    {
        // update the inventory per unit of volume
        public void AdjustInventoryCount()
        {
        }
    }

    public class MealOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
        }
    }

}
