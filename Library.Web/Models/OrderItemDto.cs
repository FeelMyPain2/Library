using System;
using System.Collections.Generic;
namespace Library.Web.Models
{
    public class OrderItemDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal RentalPrice { get; set; }
        public int Count { get; set; }
    }
}
