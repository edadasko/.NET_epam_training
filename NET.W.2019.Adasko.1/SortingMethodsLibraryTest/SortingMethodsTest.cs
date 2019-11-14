using NUnit.Framework;
using System.Linq;
using SortingMethodsLibrary;
using System;

namespace SortingMethodsLibraryTest
{
    [TestFixture]
    public class SortingMethodsTest
    {
        [TestCase(new int[0])]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 1 })]
        [TestCase(new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, -100})]
        [TestCase(new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -21, 23, 443, 22, -12, 0, 0, 1, 23, 1})]
        public void MergeSortTest(int[] unsortedArray)
            => SortTest(SortingMethods.MergeSort, unsortedArray);

        [TestCase(new int[0])]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 1 })]
        [TestCase(new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, -100 })]
        [TestCase(new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -21, 23, 443, 22, -12, 0, 0, 1, 23, 1 })]

        public void QuickSortTest(int[] unsortedArray)
            => SortTest(SortingMethods.QuickSort, unsortedArray);

        private void SortTest(Action<int[]> mySort, int[] unsortedArray)
        {
            int[] sortedArray = (int[])unsortedArray.Clone();
            Array.Sort(sortedArray);

            mySort(unsortedArray);

            Assert.AreEqual(unsortedArray, sortedArray);
        }
    }
}