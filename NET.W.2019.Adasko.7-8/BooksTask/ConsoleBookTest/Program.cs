using System;
using BooksTask;
namespace ConsoleBookTest
{
    class Program
    {
        const string storagePath = "testStorage.txt";

        static void Main(string[] args)
        {        
            Book a = new Book("A", "B", "A", "A", 2000, 1, 1);
            Book b = new Book("C", "C", "B", "C", 1999, 2, 2);
            Book c = new Book("B", "A", "C", "B", 2010, 3, 3);

            BinaryBookListStorage binaryBookListStorage = new BinaryBookListStorage(storagePath);
            BookListService bookListService = new BookListService(binaryBookListStorage);

            bookListService.AddBook(a);
            bookListService.AddBook(b);
            bookListService.AddBook(c);

            bookListService.SaveBooksToStorage();

            bookListService.SortBooksByTag(new TitleBookSorting());
            bookListService.SortBooksByTag(new AuthorBookSorting());
            bookListService.SortBooksByTag(new YearBookSorting());


            //var titleResult = bookListService.FindBooksByTag(new TitleBookFinder("1"));
            //var authorResult = bookListService.FindBooksByTag(new AuthorBookFinder("2"));
        }
    }
}
