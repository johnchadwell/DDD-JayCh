using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeClassLibrary.Models
{
    public class IGItem
    {
        public int Id { get; set; }

        [ForeignKey("FItem")]
        public int FItemId { get; set; }

        public decimal Amount { get; set; }
    }

}
