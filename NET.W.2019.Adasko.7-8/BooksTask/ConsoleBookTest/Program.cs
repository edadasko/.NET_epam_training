//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------
namespace ConsoleBookTest
{
    using BooksTask;
    using BooksTask.Finding;
    using BooksTask.Sorting;
    using BooksTask.Storage;

    /// <summary>
    /// Tests working with BookListService.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Path to binary file for permanent storage of the list.
        /// </summary>
        private const string StoragePath = "testStorage.txt";

        /// <summary>
        /// Main method of the console application.
        /// </summary>
        /// <param name="args">
        /// Passed parameters.
        /// </param>
        public static void Main(string[] args)
        {
            Book a = new Book("1-56389-668-0", "A", "B", "C", 1999, 123, 12);
            Book b = new Book("5-12231-234-9", "B", "C", "A", 1990, 453, 30);
            Book c = new Book("6-12331-454-2", "C", "A", "B", 2018, 381, 15);

            BinaryBookListStorage binaryBookListStorage = new BinaryBookListStorage(StoragePath);
            BookListService bookListService = new BookListService(binaryBookListStorage);

            bookListService.AddBook(a);
            bookListService.AddBook(b);
            bookListService.AddBook(c);

            bookListService.SaveBooksToStorage();

            bookListService.SortBooksByTag(new TitleBookSorting());
            bookListService.SortBooksByTag(new AuthorBookSorting());
            bookListService.SortBooksByTag(new YearBookDescendingSorting());

            var titleResult = bookListService.FindBooksByTag(new TitleBookFinder("A"));
            var authorResult = bookListService.FindBooksByTag(new AuthorBookFinder("B"));
        }
    }
}
