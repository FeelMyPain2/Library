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

        [SetUp]
        public void Setup()
        {
            items = new List<OrderItem>() { new OrderItem(1,1,10m),
                new OrderItem(2,3,20m),
                new OrderItem(3,1,10m)};
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
        public void OrderTotalRentalPriceWithItems()
        {
            Assert.AreEqual(10m + 20m * 3 + 10m, new Order(1, items).TotalRentalPrice);
        }
        [Test]
        public void OrderTotalBookCountWithItems()
        {
            Assert.AreEqual(1 + 3 + 1, new Order(1, items).TotalCount);
        }
    }
}
