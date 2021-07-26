using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class AdjustInventory
    {
        public int AdjustmentId { get; set; }
        public Employee Employee { get; set; }

    }

    public class StockCheckAdjustment : AdjustInventory, IAdjustInventory
    {
        public InventoryItem InventoryItem  { get; set; }
        public void AdjustInventoryCount()
        {
        }
    }
    public class SpoilageAdjustment : AdjustInventory, IAdjustInventory
    {
        public InventoryItem InventoryItem { get; set; }
        public void AdjustInventoryCount()
        {
        }
    }
    public class OtherAdjustment : AdjustInventory, IAdjustInventory
    {
        public InventoryItem InventoryItem { get; set; }
        public string Reason { get; set; }
        public void AdjustInventoryCount()
        {
        }
    }

}
