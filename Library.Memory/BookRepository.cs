using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Memory
{
    public class BookRepository : IBookRepository
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


        public Book[] GetAllByTitleOrAuthor(string titlePart)
        {

            return books.Where(book => book.Title.Contains(titlePart) ||
                                    book.Author.Contains(titlePart)).ToArray();

        }
        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            return foundBooks.ToArray();
        }

    }
}
