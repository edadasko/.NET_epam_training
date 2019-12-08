//-----------------------------------------------------------------------
// <copyright file="AuthorBookSorting.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Sorting
{
    using System;

    /// <summary>
    /// Helps to sort list of books by ascending of author name.
    /// </summary>
    public class AuthorBookSorting : BookSorting
    {
        /// <inheritdoc />
        public override int CompareByTag(Book x, Book y)
            => string.Compare(x.Author, y.Author, StringComparison.InvariantCultureIgnoreCase);
    }
}
