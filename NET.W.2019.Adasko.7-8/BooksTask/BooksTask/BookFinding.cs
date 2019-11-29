using System;
using System.Collections.Generic;

namespace BooksTask
{
    public abstract class BookFinder
    {
        public abstract bool IsBookSuitable(Book book);

        public List<Book> FindByTag(List<Book> books)
        {
            var result = new List<Book>();
            foreach (var book in books)
            {
                if (IsBookSuitable(book))
                {
                    result.Add(book);
                }
            }

            return result;
        }
    }

    public class TitleBookFinder : BookFinder
    {
        private readonly string title;

        public TitleBookFinder(string title)
        {
            this.title = title;
        }

        public override bool IsBookSuitable(Book book) =>
            string.Equals(book.Title, title, StringComparison.InvariantCultureIgnoreCase);
    }

    public class YearBookFinder : BookFinder
    {
        private readonly int year;

        public YearBookFinder(int year)
        {
            this.year = year;
        }

        public override bool IsBookSuitable(Book book) =>
            book.YearOfPublishing == year;
    }

    public class AuthorBookFinder : BookFinder
    {
        private readonly string author;

        public AuthorBookFinder(string author)
        {
            this.author = author;
        }

        public override bool IsBookSuitable(Book book) =>
            string.Equals(book.Author, author, StringComparison.InvariantCultureIgnoreCase);
    }
}
