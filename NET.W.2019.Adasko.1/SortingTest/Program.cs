using System;
using SortingMethodsLibrary;
namespace SortingTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] array = { 1, 534, -345, 24, 234, 345, 0, -123, -123231, 3, 3, 4, 24};

            array.QuickSort();

            array.MergeSort();

            Console.WriteLine();
        }
    }
}
