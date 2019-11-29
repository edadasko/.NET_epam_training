using System;
using System.Diagnostics.CodeAnalysis;

namespace BooksTask
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        #region properties
        public string ISBN { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string PublishingHouse { get; set; }

        public int YearOfPublishing { get; set; }

        public int PagesNumber { get; set; }

        public decimal Price { get; set; }
        #endregion

        public Book(string isbn, string author, string title, string publisher, int year, int pages, decimal price)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            PublishingHouse = publisher;
            YearOfPublishing = year;
            PagesNumber = pages;
            Price = price;
        }

        #region Object's methods
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Book bookObj)
            {
                this.Equals(bookObj);
            }

            return false;
        }

        public override string ToString() => this.Author + " - " + this.Title;

        public override int GetHashCode() => this.ISBN.GetHashCode();
        #endregion

        #region IComparable, IEquatable methods
        public int CompareTo(Book other)
        {
            if (other == null)
            {
                return 1;
            }

            return string.Compare(this.ISBN, other.ISBN, StringComparison.InvariantCultureIgnoreCase);
           
        }

        public bool Equals(Book other)
        {
            if (other == null)
            {
                return false;
            }

            return string.Equals(other.ISBN,this.ISBN, StringComparison.InvariantCultureIgnoreCase);
        }
        #endregion
    }
}
