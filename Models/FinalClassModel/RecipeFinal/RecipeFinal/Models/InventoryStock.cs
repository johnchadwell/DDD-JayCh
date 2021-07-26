using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class InventoryStockItem : IAdjustInventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public InventoryVendorItem InventoryVendorItem { get; set; }
        public InventoryConditionType condition { get; set; }
        public InventoryUnitType Unit { get; set; }
        public Decimal Quantity { get; set; }
        public string BarCode { get; set; }

        public void AdjustInventoryCount()
        {
        }

    }



}
