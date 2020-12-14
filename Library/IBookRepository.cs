using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public interface IBookRepository
    {
        Book[] GetAllByGenre(string genrePart);
        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);
        Book GetById(int id);
        IEnumerable<Book> GetAllByIds(IEnumerable<int> bookIds);
    }
}
