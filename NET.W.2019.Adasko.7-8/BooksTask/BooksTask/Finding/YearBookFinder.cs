//-----------------------------------------------------------------------
// <copyright file="YearBookFinder.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Finding
{
    /// <summary>
    /// Helps to filter list of books by year tag.
    /// </summary>
    public class YearBookFinder : BookFinder
    {
        /// <summary>
        /// Year field.
        /// </summary>
        private readonly int year;

        /// <summary>
        /// Initializes a new instance of the <see cref="YearBookFinder"/> class.
        /// </summary>
        /// <param name="year">
        /// Value for filtering by title tag .
        /// </param>
        public YearBookFinder(int year)
        {
            this.year = year;
        }

        /// <inheritdoc />
        public override bool IsBookSuitable(Book book) =>
            book.YearOfPublishing == this.year;
    }
}
