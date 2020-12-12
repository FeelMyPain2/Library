using System;
using System.Linq;

namespace Library.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books =
        {
            new Book(1,"Tech","Mark Adler","Book #1 foz"),
            new Book(2,"Tech","Antonio Kass","foz Book #2"),
            new Book(3,"Tech","Martin Foller","Book #3")
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
