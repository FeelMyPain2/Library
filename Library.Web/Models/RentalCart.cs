using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Models
{
    public class RentalCart
    {
        public IDictionary<int, int> Items { get; set; } = new Dictionary<int, int>();

        public decimal RentalAmount { get; set; }
    }
}
