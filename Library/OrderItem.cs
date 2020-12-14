using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class OrderItem
    {
        public int BookId { get; }

        public int Count { get; }

        public decimal RentalPrice { get; }

        public OrderItem(int bookId, int count, decimal rentalPrice)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count must be greater then zero");
            }
            BookId = bookId;
            Count = count;
            RentalPrice = rentalPrice;
        }
    }
}
