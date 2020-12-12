using System;

namespace Library
{
    public class Book
    {
        public int Id { get; }

        public string Title { get; }

        public string Genre { get; }

        public string Author { get; }
        public Book(int id, string title, string genre, string author)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Author = author;
        }
    }
}
