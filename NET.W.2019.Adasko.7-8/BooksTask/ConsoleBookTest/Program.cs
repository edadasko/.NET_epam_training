using System;
using BooksTask;
namespace ConsoleBookTest
{
    class Program
    {
        const string storagePath = "testStorage.txt";

        static void Main(string[] args)
        {        
            Book a = new Book("1", "1", "1", "1", 1, 1, 1);
            Book b = new Book("2", "2", "2", "2", 2, 2, 2);
            Book c = new Book("3", "3", "3", "3", 3, 3, 3);

            BinaryBookListStorage binaryBookListStorage = new BinaryBookListStorage(storagePath);
            BookListService bookListService = new BookListService(binaryBookListStorage);

            bookListService.GetBooksFromStorage();

            //bookListService.AddBook(a);
            //bookListService.AddBook(b);
            //bookListService.AddBook(c);
        }
    }
}
