using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public interface IBookRepository
    {
        Book[] GetAllByGenre(string genrePart);
        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);
    }
}
