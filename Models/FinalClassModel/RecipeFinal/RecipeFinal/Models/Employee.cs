using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class Employee : IPerson
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string Email { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public int GenerateId()
        {
            //generate unique employee ID
            return 0;
        }
    }
}
