using NUnit.Framework;
using Library.Memory;

namespace Library.Tests
{
    public class BookServiceTests
    {
        BookService bookService;

        [SetUp]
        public void Setup()
        {
            bookService = new BookService(new BookRepository());
        }
        [TestCase(3, "#")]
        [TestCase(3, "Book")]
        [TestCase(2, "f")]
        [TestCase(1, "#2")]
        [TestCase(0, "4242")]
        public void GetAllByTitle(int expectedResultLength, string query)
        {
            Assert.AreEqual(expectedResultLength, bookService.GetAllByQuery(query).Length);

        }
        [TestCase(1, "Genre1")]
        [TestCase(1, "Genre2")]
        [TestCase(1, "Tech")]
        [TestCase(0, "Genre")]
        public void GetAllByGenre(int expectedResultLength, string query)
        {
            Assert.AreEqual(expectedResultLength, bookService.GetAllByQuery(query).Length);

        }

    }
}