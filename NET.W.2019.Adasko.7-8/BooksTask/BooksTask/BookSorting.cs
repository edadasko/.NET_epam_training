using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BooksTask
{
    public abstract class BookSorting : IComparer<Book>
    {
        public abstract int CompareByTag(Book x, Book y);

        public int Compare(Book x, Book y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }

            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            return CompareByTag(x, y);
        }
    }

    public class TitleBookSorting : BookSorting
    {
        public override int CompareByTag(Book x, Book y)
            => string.Compare(x.Title, y.Title, StringComparison.InvariantCultureIgnoreCase);
    }

    public class TitleBookDescendingSorting : BookSorting
    {
        public override int CompareByTag(Book x, Book y)
            => string.Compare(y.Title, x.Title, StringComparison.InvariantCultureIgnoreCase);
    }

    public class YearBookSorting : BookSorting
    {
        public override int CompareByTag(Book x, Book y)
            => x.YearOfPublishing.CompareTo(y.YearOfPublishing);
    }

    public class YearBookDescendingSorting : BookSorting
    {
        public override int CompareByTag(Book x, Book y)
            => y.YearOfPublishing.CompareTo(x.YearOfPublishing);
    }

    public class AuthorBookSorting : BookSorting
    {
        public override int CompareByTag(Book x, Book y)
            => string.Compare(x.Author, y.Author, StringComparison.InvariantCultureIgnoreCase);
    }

    public class AuthorBookDescendingSorting : BookSorting
    {
        public override int CompareByTag(Book x, Book y)
            => string.Compare(y.Author, x.Author, StringComparison.InvariantCultureIgnoreCase);
    }

}
