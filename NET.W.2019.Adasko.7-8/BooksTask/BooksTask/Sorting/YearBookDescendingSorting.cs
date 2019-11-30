//-----------------------------------------------------------------------
// <copyright file="YearBookDescendingSorting.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Sorting
{
    /// <summary>
    /// Helps to sort list of books by descending of year.
    /// </summary>
    public class YearBookDescendingSorting : BookSorting
    {
        /// <inheritdoc />
        public override int CompareByTag(Book x, Book y)
            => y.YearOfPublishing.CompareTo(x.YearOfPublishing);
    }
}
