using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class InventoryVendorItem
    {
        public int InventoryVendorItemId { get; set; }
        public Vendor Vendor { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public string Name { get; set; }



    }
}
