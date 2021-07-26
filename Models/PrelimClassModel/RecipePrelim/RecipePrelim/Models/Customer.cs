using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class Customer : IPerson
    {
        public int Id { get; set; }
        public PersonType PersonType { get; set; }
        public string TableNbr { get; set; }
        public int NbrInParty { get; set; }

        public int GenerateId()
        {
            //generate unique customer ID
            return 1;
        }

    }
}
