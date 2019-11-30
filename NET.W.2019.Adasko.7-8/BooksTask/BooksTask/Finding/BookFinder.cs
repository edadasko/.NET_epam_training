//-----------------------------------------------------------------------
// <copyright file="BookFinder.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Finding
{
    using System.Collections.Generic;

    /// <summary>
    /// Abstract class which helps to filter collection by some tag.
    /// This class with its subclasses represent the Template method pattern.
    /// </summary>
    public abstract class BookFinder
    {
        /// <summary>
        /// Checks if the passed book should be in the resulting list.
        /// The part of the Template method pattern.
        /// </summary>
        /// <param name="book">
        /// Book to check.
        /// </param>
        /// <returns>
        /// Is book is suitable for filtered list. 
        /// </returns>
        public abstract bool IsBookSuitable(Book book);

        /// <summary>
        /// Filters passed collection using abstract IsBookSuitable method,
        /// which should be overriding by some subclass and provides tag for filtering.
        /// The template method.
        /// </summary>
        /// <param name="books">
        /// List of books for filtering.
        /// </param>
        /// <returns>
        /// Filtered list.
        /// </returns>
        public List<Book> FindByTag(List<Book> books)
        {
            var result = new List<Book>();
            foreach (var book in books)
            {
                if (this.IsBookSuitable(book))
                {
                    result.Add(book);
                }
            }

            return result;
        }
    }
}
