//-----------------------------------------------------------------------
// <copyright file="Book.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents the Book class.
    /// </summary>
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        #region fields

        /// <summary>
        /// ISBN field.
        /// </summary>
        private string isbn;

        /// <summary>
        /// Author field.
        /// </summary>
        private string author;

        /// <summary>
        /// Title field.
        /// </summary>
        private string title;

        /// <summary>
        /// Publishing house field.
        /// </summary>
        private string publishingHouse;

        /// <summary>
        /// Year of publishing field.
        /// </summary>
        private int year;

        /// <summary>
        /// Number of pages field.
        /// </summary>
        private int pages;

        /// <summary>
        /// Price field.
        /// </summary>
        private decimal price;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">
        /// ISBN value.
        /// </param>
        /// <param name="author">
        /// Author value.
        /// </param>
        /// <param name="title">
        /// Title value.
        /// </param>
        /// <param name="publisher">
        /// Publishing house value.
        /// </param>
        /// <param name="year">
        /// Year of publishing value.
        /// </param>
        /// <param name="pages">
        /// Number of pages value.
        /// </param>
        /// <param name="price">
        /// Price value.
        /// </param>
        public Book(string isbn, string author, string title, string publisher, int year, int pages, decimal price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Title = title;
            this.PublishingHouse = publisher;
            this.YearOfPublishing = year;
            this.PagesNumber = pages;
            this.Price = price;
        }

        #region properties
        /// <summary>
        /// Gets ISBN.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws when passed string is null or empty or if it does not match ISBN pattern.
        /// </exception>
        public string ISBN
        {
            get
            {
                return this.isbn;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                string patternISBN = @"\d{1,5}([- ])\d{1,7}\1\d{1,6}\1(\d|X)$";

                if (!Regex.IsMatch(value, patternISBN))
                {
                    throw new ArgumentException();
                }

                this.isbn = value;
            }
        }

        /// <summary>
        /// Gets author.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws when passed string is null or empty.
        /// </exception>
        public string Author
        {
            get
            {
                return this.author;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                this.author = value;
            }
        }

        /// <summary>
        /// Gets title.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws when passed string is null or empty.
        /// </exception>
        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                this.title = value;
            }
        }

        /// <summary>
        /// Gets publishing house.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws when passed string is null or empty.
        /// </exception>
        public string PublishingHouse
        {
            get
            {
                return this.publishingHouse;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                this.publishingHouse = value;
            }
        }

        /// <summary>
        /// Gets year of publishing.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws when passed year is negative or bigger than current year.
        /// </exception>
        public int YearOfPublishing
        {
            get
            {
                return this.year;
            }

            private set
            {
                if (value <= 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException();
                }

                this.year = value;
            }
        }

        /// <summary>
        /// Gets pages of publishing string.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws when passed number is negative.
        /// </exception>
        public int PagesNumber
        {
            get
            {
                return this.pages;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.pages = value;
            }
        }

        /// <summary>
        /// Gets price.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws when passed number is negative.
        /// </exception>
        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.price = value;
            }
        }
        #endregion

        #region Object's methods

        /// <inheritdoc />
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

        /// <inheritdoc />
        public override string ToString() => this.Author + " - " + this.Title;

        /// <inheritdoc />
        public override int GetHashCode() => this.ISBN.GetHashCode();
        #endregion

        #region IComparable, IEquatable methods

        /// <inheritdoc />
        public int CompareTo(Book other)
        {
            if (other == null)
            {
                return 1;
            }

            return string.Compare(this.ISBN, other.ISBN, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc />
        public bool Equals(Book other)
        {
            if (other == null)
            {
                return false;
            }

            return string.Equals(other.ISBN, this.ISBN, StringComparison.InvariantCultureIgnoreCase);
        }
        #endregion
    }
}
