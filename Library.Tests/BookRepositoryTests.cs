using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;
namespace Library.Tests
{
    [TestFixture]
    class BookRepositoryTests
    {
        BookRepositoryMock repositoryMock;
        [SetUp]
        public void Setup()
        {
            repositoryMock = new BookRepositoryMock();
        }


        [Test]
        public void GetBookByRightId()
        {
            Assert.AreEqual(repositoryMock.GetById(1).Author, "Mark Adler");
        }
        [Test]
        public void GetBookByFalseId()
        {
            Assert.AreNotEqual(repositoryMock.GetById(2).Author, "Mark Adler");

        }
        [Test]
        public void GetBookByOutOfRangeId()
        {
            Assert.Throws<InvalidOperationException>(() => repositoryMock.GetById(5));

        }
        [Test]
        public void GetBooksByIds()
        {
            var byIds = repositoryMock.GetAllByIds(new List<int>() { 1, 2 });

            Assert.AreEqual(repositoryMock.books.First(book => book.Id == 1), byIds[0]);
            Assert.AreEqual(repositoryMock.books.First(book => book.Id == 2), byIds[1]);

        }
    }
}
