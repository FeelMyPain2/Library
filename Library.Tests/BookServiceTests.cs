using Moq;
using NUnit.Framework;
using Library.Memory;
using System.Linq;
using System.Collections.Generic;

namespace Library.Tests
{
    public class BookRepositoryMock : IBookRepository
    {
        readonly Book[] books =
        {
            new Book(1,"Book #1 foz","Genre1","Mark Adler","Some description",1.3m ),
            new Book(2,"Book #3","Genre2","Martin Foller" ,"Some description",2.3m ),
            new Book(3,"foz Book #2","Tech","Antonio Kass","Some description",3.3m )
        };
        public Book[] GetAllByGenre(string genre)
        {
            return books.Where(book => book.Genre == genre).ToArray();
        }

        public IEnumerable<Book> GetAllByIds(IEnumerable<int> bookIds)
        {
            throw new System.NotImplementedException();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Title.Contains(query) ||
                                        book.Author.Contains(query)).ToArray();
        }
        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
    public class BookServiceTests
    {
        BookService bookService;

        [SetUp]
        public void Setup()
        {
            bookService = new BookService(new BookRepositoryMock());
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
        [TestCase(1, "Mark")]
        [TestCase(1, "Kass")]
        [TestCase(1, "Martin Fol")]
        [TestCase(0, "Sanin")]
        public void GetAllByAuthor(int expectedResultLength, string query)
        {
            Assert.AreEqual(expectedResultLength, bookService.GetAllByQuery(query).Length);

        }


    }
}