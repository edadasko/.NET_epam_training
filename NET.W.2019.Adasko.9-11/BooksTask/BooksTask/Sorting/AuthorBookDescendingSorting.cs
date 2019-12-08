//-----------------------------------------------------------------------
// <copyright file="AuthorBookDescendingSorting.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Sorting
{
    using System;

    /// <summary>
    /// Helps to sort list of books by descending of author name.
    /// </summary>
    public class AuthorBookDescendingSorting : BookSorting
    {
        /// <inheritdoc />
        public override int CompareByTag(Book x, Book y)
            => string.Compare(y.Author, x.Author, StringComparison.InvariantCultureIgnoreCase);
    }
}
