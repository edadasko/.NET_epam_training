//-----------------------------------------------------------------------
// <copyright file="BookListService.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using BooksTask.Finding;
    using BooksTask.Logging;
    using BooksTask.Storage;

    /// <summary>
    /// Provides operations with list of Books objects.
    /// </summary>
    public class BookListService
    {
        /// <summary>
        /// Permanent storage for list of Books. Should consists save and load methods.
        /// </summary>
        private readonly IBookListStorage bookStorage;

        /// <summary>
        /// Logger field.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="storage">
        /// Permanent storage.
        /// </param>
        /// <param name="logger">
        /// Specific logger.
        /// </param>
        public BookListService(IBookListStorage storage, ILogger logger)
        {
            this.Books = new List<Book>();
            this.bookStorage = storage;
            this.logger = logger;
        }

        /// <summary>
        /// Gets list of books.
        /// </summary>
        public List<Book> Books { get; private set; }

        /// <summary>
        /// Loads all books from permanent storage.
        /// </summary>
        public void GetBooksFromStorage()
        {
            this.Books = this.bookStorage.GetBooks().ToList();
            this.logger.Info("Books have been loaded from storage.");
        }

        /// <summary>
        /// Saves all books to permanent storage.
        /// </summary>
        public void SaveBooksToStorage()
        {
            this.bookStorage.SaveBooks(this.Books);
            this.logger.Info("Books have been saved to storage.");
        }

        /// <summary>
        /// Adds new book to list.
        /// </summary>
        /// <param name="book">
        /// Book to add.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws when passed book is in the list already.
        /// </exception>
        public void AddBook(Book book)
        {
            if (book == null)
            {
                this.logger.Error("Added book is null.");

                throw new ArgumentNullException();
            }

            if (this.Books.Contains(book))
            {
                this.logger.Error("Added duplicate to storage.");

                throw new ArgumentException("There is such book already.");
            }

            this.Books.Add(book);
            
            this.logger.Info(string.Format(CultureInfo.CurrentCulture, "{0:TA}", book) + " have been added.");
        }

        /// <summary>
        /// Remove passed book from list.
        /// </summary>
        /// <param name="book">
        /// Book to remove.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws when there is no such book in the list.
        /// </exception>
        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                this.logger.Error("Removing book is null");

                throw new ArgumentNullException();
            }

            if (!this.Books.Contains(book))
            {
                this.logger.Error("Trying to remove nonexistent book.");

                throw new ArgumentException("There is not such book.");
            }

            this.Books.Remove(book);

            this.logger.Info(string.Format(CultureInfo.CurrentCulture, "{0:TA}", book) + "have been removed.");
        }

        /// <summary>
        /// Finds books by the given tag.
        /// </summary>
        /// <param name="finder">
        /// Subclass of BookFinder class which has tag and value for searching.
        /// This class overrides FindByTag method of BookFinder class which filters list by the given tag.
        /// </param>
        /// <returns>
        /// Filtered list by a tag.
        /// </returns>
        public List<Book> FindBooksByTag(BookFinder finder) => finder.FindByTag(this.Books);

        /// <summary>
        /// Sorts books by the given tag.
        /// </summary>
        /// <param name="comparer">
        /// The class which provides logic of sorting. Should overrides Compare method of IComparer interface.
        /// </param>
        public void SortBooksByTag(IComparer<Book> comparer) => this.Books.Sort(comparer);
    }
}
