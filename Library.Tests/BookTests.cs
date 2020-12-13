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
        [TestCase("   ")]
        [TestCase("Tec")]
        [TestCase("Tech4")]
        public void IsGenre_Exist_ReturnFalse(string query)
        {
            Assert.IsFalse(Book.IsGenre(query));
        }

        [TestCase("Genre1")]
        [TestCase("Genre2")]
        [TestCase("Tech")]
        public void IsGenre_Exist_ReturnTrie(string query)
        {
            Assert.IsTrue(Book.IsGenre(query));
        }
    }
}
