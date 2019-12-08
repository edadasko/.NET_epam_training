//-----------------------------------------------------------------------
// <copyright file="IBookListStorage.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Storage
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for permanent storage of list of books.
    /// </summary>
    public interface IBookListStorage
    {
        /// <summary>
        /// Gets books from storage.
        /// </summary>
        /// <returns>
        /// Books which have been saved in the storage.
        /// </returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Saves books to storage.
        /// </summary>
        /// <param name="books">
        /// Books to save.
        /// </param>
        void SaveBooks(IEnumerable<Book> books);
    }
}
