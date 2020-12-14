using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace Library.Tests
{
    [TestFixture]
    class BookRepositoryTests
    {
        [Test]
        public void GetBookByRightId()
        {
            Assert.AreEqual(new BookRepositoryMock().GetById(1).Author, "Mark Adler");
        }
        [Test]
        public void GetBookByFalseId()
        {
            Assert.AreNotEqual(new BookRepositoryMock().GetById(2).Author, "Mark Adler");

        }
        [Test]
        public void GetBookByOutOfRangeId()
        {
            BookRepositoryMock repositoryMock = new BookRepositoryMock();
            Assert.Throws<InvalidOperationException>(() => repositoryMock.GetById(5));

        }
    }
}
