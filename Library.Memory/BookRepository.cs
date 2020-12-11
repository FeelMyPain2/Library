using System;
using System.Linq;

namespace Library.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books =
        {
            new Book(1,"Book #1 foz"),
            new Book(2,"foz Book #2"),
            new Book(3,"Book #3")
        };
        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }
    }
}
