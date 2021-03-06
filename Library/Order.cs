﻿using System.Collections.Generic;
using System.Linq;
using System;
namespace Library
{
    public class Order
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
            get { return Items.Sum(item => item.RentalPrice * item.Count); }
        }
        public DateTime Date { get; set; }
        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            Id = id;
            this.items = new List<OrderItem>(items);
            Date = DateTime.Now;

        }
        public void AddItem(Book book, int count)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            var item = items.SingleOrDefault(orderItem => orderItem.BookId == book.Id);

            if (item == null)
            {
                items.Add(new OrderItem(book.Id, count, book.RentalPrice));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(book.Id, item.Count + count, book.RentalPrice));
            }
        }
        public void RemoveItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (items.Count == 0)
                throw new InvalidOperationException("Rental cart must contain items");

            var item = items.SingleOrDefault(x => x.BookId == book.Id);
            if (item == null)
                throw new InvalidOperationException("Rental cart does not contain item with ID: " + book.Id);

            items.Remove(item);
            if (item.Count - count == 0)
                return;

            items.Add(new OrderItem(book.Id, item.Count - count, book.RentalPrice));
        }

        public void RemoveItems(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (items.Count == 0)
                throw new InvalidOperationException("Rental cart must contain items");

            var item = items.SingleOrDefault(x => x.BookId == book.Id);
            if (item == null)
                throw new InvalidOperationException("Rental cart does not contain item with ID: " + book.Id);

            items.RemoveAll(x => x.BookId == book.Id);
        }
    }
}
