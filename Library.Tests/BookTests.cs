using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace Library.Tests
{
    [TestFixture]
    class BookTests
    {
        [TestCase(null)]
        [TestCase("Genre")]
        public void IsGenre_WithNull_ReturnFalse(string query)
        {
            Assert.IsFalse(Book.IsGenre(query));
        }
        [Test]
        public void IsGenre_Exist_ReturnTrue()
        {
            Assert.IsTrue(Book.IsGenre("Tech"));
        }
    }
}
