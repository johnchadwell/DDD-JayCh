using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeAPI1.Models;
using RecipeClassLibrary.Models;

namespace RecipeAPI1.Repositories
{
    public interface IEmployeeRepository
    {
        int NewEmployee(Employee c);
        Employee GetEmployee(int id);
        //IEnumerable<Customer> GetAllCustomers();
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        RecipeContext ctx;
        public EmployeeRepository(RecipeContext context)
        {
            ctx = context;
        }
        public int NewEmployee(Employee c)
        {
            ctx.Employees.Add(c);
            int res = ctx.SaveChanges();
            return res;
        }
        public Employee GetEmployee(int id)
        {
            Employee c = ctx.Employees.FirstOrDefault(b => b.Id == id);
            return c;
        }
    }
}
