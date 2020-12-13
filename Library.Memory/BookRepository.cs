using System;
using System.Linq;

namespace Library.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books =
        {
            new Book(1,"Book #1 foz","Genre2","Mark Adler"),
            new Book(2,"foz Book #2","Tech","Antonio Kass"),
            new Book(3,"Book #3","Genre1","Martin Foller")
        };

        public Book[] GetAllByGenre(string genrePart)
        {
            return books.Where(book => book.Genre.Contains(genrePart)).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }
    }
}
