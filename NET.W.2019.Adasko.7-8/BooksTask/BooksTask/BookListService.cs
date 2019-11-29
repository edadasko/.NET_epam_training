using System;
using System.Linq;
using System.Collections.Generic;

namespace BooksTask
{
    public class BookListService
    {
        private readonly IBookListStorage bookStorage;

        public List<Book> Books { get; private set; }

        public BookListService(IBookListStorage storage)
        {
            Books = new List<Book>();
            bookStorage = storage;
        }

        public void GetBooksFromStorage() => Books = bookStorage.GetBooks().ToList();

        public void SaveBooksToStorage() => bookStorage.SaveBooks(Books);

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            if (Books.Contains(book))
            {
                throw new ArgumentException("There is such book already.");
            }

            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            if (!Books.Contains(book))
            {
                throw new ArgumentException("There is not such book.");
            }

            Books.Remove(book);
        }
    }
}
