//-----------------------------------------------------------------------
// <copyright file="AuthorBookFinder.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Finding
{
    using System;

    /// <summary>
    /// Helps to filter list of books by author tag.
    /// </summary>
    public class AuthorBookFinder : BookFinder
    {
        /// <summary>
        /// Author field.
        /// </summary>
        private readonly string author;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorBookFinder"/> class.
        /// </summary>
        /// <param name="author">
        /// Value for filtering by author tag .
        /// </param>
        public AuthorBookFinder(string author)
        {
            this.author = author;
        }

        /// <inheritdoc />
        public override bool IsBookSuitable(Book book) =>
            string.Equals(book.Author, this.author, StringComparison.InvariantCultureIgnoreCase);
    }
}
