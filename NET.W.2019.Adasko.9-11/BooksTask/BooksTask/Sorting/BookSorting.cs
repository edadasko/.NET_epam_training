//-----------------------------------------------------------------------
// <copyright file="BookSorting.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Sorting
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Abstract class which helps to sort collection by some tag.
    /// </summary>
    public abstract class BookSorting : IComparer<Book>
    {
        /// <summary>
        /// Defines logic for sorting list of books.
        /// </summary>
        /// <param name="x">
        /// The first book.
        /// </param>
        /// <param name="y">
        /// The second book.
        /// </param>
        /// <returns>
        /// Positive number if the first book should be righter than the second book in a sorted list.
        /// 0 if the are equals.
        /// Negative number otherwise.
        /// </returns>
        public abstract int CompareByTag(Book x, Book y);

        /// <inheritdoc />
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

            return this.CompareByTag(x, y);
        }
    }
}
