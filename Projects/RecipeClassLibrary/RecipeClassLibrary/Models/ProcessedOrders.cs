using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class ProcessedOrders
    {
        public int Id { get; set; }
        public DateTime processedDate { get; set; }
        public int OrderRef { get; set; }
        public int InventoryRef { get; set; }
        public decimal Deduction { get; set; }

    }
}
