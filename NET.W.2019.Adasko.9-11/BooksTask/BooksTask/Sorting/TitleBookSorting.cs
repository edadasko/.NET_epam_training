//-----------------------------------------------------------------------
// <copyright file="TitleBookSorting.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Sorting
{
    using System;

    /// <summary>
    /// Helps to sort list of books by ascending of title.
    /// </summary>
    public class TitleBookSorting : BookSorting
    {
        /// <inheritdoc />
        public override int CompareByTag(Book x, Book y)
            => string.Compare(x.Title, y.Title, StringComparison.InvariantCultureIgnoreCase);
    }
}
