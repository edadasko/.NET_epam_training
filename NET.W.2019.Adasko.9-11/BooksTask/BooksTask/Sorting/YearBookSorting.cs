//-----------------------------------------------------------------------
// <copyright file="YearBookSorting.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Sorting
{
    /// <summary>
    /// Helps to sort list of books by ascending of year.
    /// </summary>
    public class YearBookSorting : BookSorting
    {
        /// <inheritdoc />
        public override int CompareByTag(Book x, Book y)
            => x.YearOfPublishing.CompareTo(y.YearOfPublishing);
    }
}
