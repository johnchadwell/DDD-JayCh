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
        public decimal Cost { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }
        public MenuItem MenuItem { get; set; }
        public OptionalMenuItem OptionalMenuItem { get; set; }

    }

    public class CopyOfOrderItem
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }
        public MenuItem MenuItem { get; set; }
        public OptionalMenuItem OptionalMenuItem { get; set; }

    }

    public class CopyOfAlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }

    public class CopyOfCopyOfAlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }

    public class CopyOfCopyOfCopyOfAlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }
    public class AlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }

    public class Copy1OfAlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }

    public class CopyOfCopy1OfAlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }

    public class Copy1OfCopyOfCopy1OfAlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }

    public class CopyOfCopyOfCopy1OfAlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }

    public class Copy1OfCopyOfCopyOfCopy1OfAlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }

    public class CopyOfCopy1OfCopyOfCopyOfCopy1OfAlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }

    public class CopyOfCopyOfCopyOfCopy1OfAlaCarteOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
            // update all ingredients from recipe in inventory
        }
    }

    public class CopyOfCopyOfMealOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
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

    public class CopyOfCopy1OfCopyOfMealOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
        }
    }

    public class Copy1OfCopyOfMealOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
        }
    }

    public class CopyOfMealOrderItem : OrderItem, IAdjustInventory
    {
        public void AdjustInventoryCount()
        {
        }
    }

    public class CopyOfCopyOfCopyOfCopy1OfBeverageOrderItem : OrderItem, IAdjustInventory
    {
        // update the inventory per unit of volume
        public void AdjustInventoryCount()
        {
        }
    }

    public class CopyOfCopyOfCopy1OfBeverageOrderItem : OrderItem, IAdjustInventory
    {
        // update the inventory per unit of volume
        public void AdjustInventoryCount()
        {
        }
    }

    public class CopyOfCopyOfCopyOfCopyOfBeverageOrderItem : OrderItem, IAdjustInventory
    {
        // update the inventory per unit of volume
        public void AdjustInventoryCount()
        {
        }
    }

    public class CopyOfCopy1OfBeverageOrderItem : OrderItem, IAdjustInventory
    {
        // update the inventory per unit of volume
        public void AdjustInventoryCount()
        {
        }
    }

    public class CopyOfCopyOfCopyOfBeverageOrderItem : OrderItem, IAdjustInventory
    {
        // update the inventory per unit of volume
        public void AdjustInventoryCount()
        {
        }
    }

    public class Copy1OfBeverageOrderItem : OrderItem, IAdjustInventory
    {
        // update the inventory per unit of volume
        public void AdjustInventoryCount()
        {
        }
    }

    public class CopyOfCopyOfBeverageOrderItem : OrderItem, IAdjustInventory
    {
        // update the inventory per unit of volume
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

    public class CopyOfBeverageOrderItem : OrderItem, IAdjustInventory
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
