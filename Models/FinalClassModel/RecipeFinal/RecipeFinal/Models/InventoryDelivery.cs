using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class InventoryDelivery: IAdjustInventory
    {
        public int InventoryDeliveryId { get; set; }
        public InventoryOrder InventoryOrder { get; set; }
        public InventoryVendorItem InventoryVendorItem { get; set; }
        public int AmountDelivered { get; set; }
        public string Barcode { get; set; }
        public void AdjustInventoryCount()
        {
            //Adjust InventoryStock quantity
        }

    }
}
