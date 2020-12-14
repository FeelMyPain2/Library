using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Models
{
    public class RentalCart
    {
        public int OrderId { get; }
        public int TotalCount { get; set; }
        public decimal TotalRentalPrice { get; set; }

        public RentalCart(int orderId)
        {
            OrderId = orderId;
            TotalCount = 0;
            TotalRentalPrice = 0.0m;
        }
    }
}
