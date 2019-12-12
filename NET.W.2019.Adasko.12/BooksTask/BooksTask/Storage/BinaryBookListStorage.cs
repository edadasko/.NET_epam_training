//-----------------------------------------------------------------------
// <copyright file="BinaryBookListStorage.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Storage
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Provides permanent storage for books list using binary file.
    /// </summary>
    public class BinaryBookListStorage : IBookListStorage
    {
        /// <summary>
        /// Path to the binary file.
        /// </summary>
        private readonly string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryBookListStorage"/> class.
        /// </summary>
        /// <param name="path">
        /// Path to the binary file.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when the path is null.
        /// </exception>
        public BinaryBookListStorage(string path)
        {
            this.filePath = path ?? throw new ArgumentNullException();
        }

        /// <inheritdoc />
        public IEnumerable<Book> GetBooks()
        {
            if (!File.Exists(this.filePath))
            {
                throw new InvalidOperationException("There is not such file.");
            }
            
            List<Book> books = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(this.filePath, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string isbn = reader.ReadString();
                    string author = reader.ReadString();
                    string title = reader.ReadString();
                    string publisher = reader.ReadString();
                    int pages = reader.ReadInt32();
                    int year = reader.ReadInt32();
                    decimal price = reader.ReadDecimal();

                    books.Add(new Book(isbn, author, title, publisher, year, pages, price));
                }
            }

            return books;
        }

        /// <inheritdoc />
        public void SaveBooks(IEnumerable<Book> books)
        {
            using BinaryWriter writer = new BinaryWriter(File.Open(this.filePath, FileMode.Create));

            foreach (Book b in books)
            {
                writer.Write(b.ISBN);
                writer.Write(b.Author);
                writer.Write(b.Title);
                writer.Write(b.PublishingHouse);
                writer.Write(b.PagesNumber);
                writer.Write(b.YearOfPublishing);
                writer.Write(b.Price);
            }
        }
    }
}
