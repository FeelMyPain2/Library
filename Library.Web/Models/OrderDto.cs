using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public OrderItemDto[] Items { get; set; } = new OrderItemDto[0];
        public int TotalCount { get; set; }
        public decimal TotalRentalPrice { get; set; }
    }
}
