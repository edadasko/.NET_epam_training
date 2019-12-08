//-----------------------------------------------------------------------
// <copyright file="TitleBookFinder.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Finding
{
    using System;

    /// <summary>
    /// Helps to filter list of books by title tag.
    /// </summary>
    public class TitleBookFinder : BookFinder
    {
        /// <summary>
        /// Title field.
        /// </summary>
        private readonly string title;

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleBookFinder"/> class.
        /// </summary>
        /// <param name="title">
        /// Value for filtering by title tag .
        /// </param>
        public TitleBookFinder(string title)
        {
            this.title = title;
        }

        /// <inheritdoc />
        public override bool IsBookSuitable(Book book) =>
            string.Equals(book.Title, this.title, StringComparison.InvariantCultureIgnoreCase);
    }
}
