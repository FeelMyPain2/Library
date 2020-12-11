using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public interface IBookRepository
    {
        Book[] GetAllByTitle(string titlePart);
    }
}
