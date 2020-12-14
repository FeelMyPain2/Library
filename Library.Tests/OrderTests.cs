using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Library.Tests
{
    [TestFixture]
    class OrderTests
    {
        List<OrderItem> items;
        Order standardOrder;

        [SetUp]
        public void Setup()
        {
            items = new List<OrderItem>() { new OrderItem(1,1,10m),
                new OrderItem(2,3,20m),
                new OrderItem(3,1,10m)};
            standardOrder = new Order(1, items);
        }
        [Test]
        public void OrderWithNullItems()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }
        [Test]
        public void OrderTotalRentalPriceWithEmptyItem()
        {
            Assert.AreEqual(0m, new Order(1, new OrderItem[0]).TotalRentalPrice);
        }
        [Test]
        public void StandardOrderTotalRentalPrice()
        {
            Assert.AreEqual(10m + 20m * 3 + 10m, standardOrder.TotalRentalPrice);
        }
        [Test]
        public void StandardOrderTotalBookCount()
        {
            Assert.AreEqual(1 + 3 + 1, standardOrder.TotalCount);
        }

        [Test]
        public void AddNullAsNewBook()
        {
            Assert.Throws<ArgumentNullException>(() => standardOrder.AddItem(null, 33));
        }
        [Test]
        public void AddBookToOrderThatAlreadyInOrder()
        {
            Order order = standardOrder;
            order.AddItem(new Book(1, "", "", "", "", 10m), 2);
            Assert.AreEqual(5 + 2, order.TotalCount);
            Assert.AreEqual(3, order.Items.Count);
        }
        [Test]
        public void AddNewBookToOrder()
        {
            Order order = standardOrder;
            order.AddItem(new Book(4, "", "", "", "", 100m), 3);
            Assert.AreEqual(5 + 3, order.TotalCount);
            Assert.AreEqual(3 + 1, order.Items.Count);
            Assert.AreEqual(380m, order.TotalRentalPrice);
        }
    }
}
