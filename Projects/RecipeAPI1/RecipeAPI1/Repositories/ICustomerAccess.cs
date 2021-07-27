using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface ICustomerRepository
    {
        int NewCustomer(Customer c);
        Customer GetCustomer(int id);
        //IEnumerable<Customer> GetAllCustomers();
    }
    public class CustomerRepository : ICustomerRepository
    {
        RecipeContext ctx;
        public CustomerRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewCustomer(Customer c)
        {
            ctx.Customers.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public Customer GetCustomer(int id)
        {
            Customer c = ctx.Customers.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
