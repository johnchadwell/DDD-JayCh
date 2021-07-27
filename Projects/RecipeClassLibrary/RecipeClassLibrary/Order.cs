 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public double TotalCost()
        {
            return 0.0;
        }

    }
}
