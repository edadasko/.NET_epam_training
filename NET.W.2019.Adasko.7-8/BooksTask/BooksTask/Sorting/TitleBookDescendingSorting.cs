//-----------------------------------------------------------------------
// <copyright file="TitleBookDescendingSorting.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Sorting
{
    using System;

    /// <summary>
    /// Helps to sort list of books by descending of title.
    /// </summary>
    public class TitleBookDescendingSorting : BookSorting
    {
        /// <inheritdoc />
        public override int CompareByTag(Book x, Book y)
            => string.Compare(y.Title, x.Title, StringComparison.InvariantCultureIgnoreCase);
    }
}
