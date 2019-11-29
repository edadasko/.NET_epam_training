using System;
using System.Collections;
using System.Collections.Generic;

namespace BooksTask
{
    public interface IBookListStorage
    {
        IEnumerable<Book> GetBooks();

        void SaveBooks(IEnumerable<Book> books);
    }
}
