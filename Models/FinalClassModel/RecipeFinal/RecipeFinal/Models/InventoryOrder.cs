using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class InventoryOrder
    {
        public int InventoryOrderId { get; set; }
        public InventoryVendorItem InventoryVendorItem { get; set; }
        public List<InventoryDelivery> Deliveries { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public DateTime DeliverByDate { get; set; }

    }
}
