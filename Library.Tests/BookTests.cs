using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace Library.Tests
{
    [TestFixture]
    class BookTests
    {
        [Test]
        public void IsGenre_WithNull_ReturnFalse()
        {
            Assert.IsFalse(Book.IsGenre(null));
        }
    }
}
