using System;
using System.Linq;

namespace Library
{
    public class Book
    {
        public static string[] genres = { "Genre1", "Tech", "Genre2" };

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

        internal static bool IsGenre(string query)
        {
            return genres.Contains(query);
        }
    }
}
