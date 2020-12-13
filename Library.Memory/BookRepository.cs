using System;
using System.Linq;

namespace Library.Memory
{
    public class BookRepository : IBookRepository
    {
        readonly Book[] books =
        {
            new Book(1,"Book #1 foz","Genre1","Mark Adler"),
            new Book(2,"Book #3","Genre2","Martin Foller"),
            new Book(3,"foz Book #2","Tech","Antonio Kass")
        };

        public Book[] GetAllByGenre(string genre)
        {
            return books.Where(book => book.Genre == genre).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart) ||
                                        book.Author.Contains(titlePart)).ToArray();
        }
    }
}
