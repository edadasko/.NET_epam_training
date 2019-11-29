using System;
using System.Collections.Generic;
using System.IO;

namespace BooksTask
{
    public class BinaryBookListStorage : IBookListStorage
    {
        private readonly string filePath;

        public BinaryBookListStorage(string path)
        {
            this.filePath = path ?? throw new ArgumentNullException();
        }

        public IEnumerable<Book> GetBooks()
        {
            if (!File.Exists(filePath)) throw new InvalidOperationException("There is not such file.");

            List<Book> books = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
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

        public void SaveBooks(IEnumerable<Book> books)
        {
            using BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create));

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
