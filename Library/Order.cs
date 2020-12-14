using System.Collections.Generic;
using System.Linq;
using System;
namespace Library
{
    class Order
    {
        public int Id { get; }

        List<OrderItem> items;
        public IReadOnlyCollection<OrderItem> Items
        {
            get { return items; }
        }
        public int TotalCount
        {
            get { return items.Sum(item => item.Count); }
        }
        public decimal TotalRentalPrice
        {
            get { return items.Sum(item => item.RentalPrice * item.Count); }
        }
        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            Id = id;
            this.items = new List<OrderItem>(items);
        }
    }
}
