using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace Library.Tests
{
    [TestFixture]
    public class OrderItemTests
    {
        [Test]
        public void OrderItemPropInit()
        {
            OrderItem item = new OrderItem(1, 2, 3m);
            Assert.AreEqual(1, item.BookId);
            Assert.AreEqual(2, item.Count);
            Assert.AreEqual(3m, item.RentalPrice);
        }

        [TestCase(0)]
        [TestCase(-3)]
        [TestCase(null)]
        public void OrderItemWithOfRangeCount(int itemCount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem(1, itemCount, 42));
        }

        [TestCase(2, 2)]
        [TestCase(555555555, 555555555)]
        public void OrderItemWithRightCount(int expectedItemCount, int itemCount)
        {
            Assert.AreEqual(expectedItemCount, new OrderItem(1, itemCount, 42m).Count);
        }


    }
}
