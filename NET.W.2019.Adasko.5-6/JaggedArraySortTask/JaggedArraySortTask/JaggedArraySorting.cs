//-----------------------------------------------------------------------
// <copyright file="JaggedArraySorting.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace JaggedArraySortTask
{
    using System;
    using System.Linq;

    /// <summary>
    /// Provides extension methods for sorting
    /// jagged arrays with different sorting criterions.
    /// </summary>
    public static class JaggedArraySorting
    {
        /// <summary>
        /// Sorts jagged array by ascending of sums of its rows elements.
        /// </summary>
        /// <param name="array">
        /// Jagged array for sorting.
        /// </param>
        public static void OrderBySum(this int[][] array) =>
            BubbleSort(array, (a, b) => a.Sum() > b.Sum());

        /// <summary>
        /// Sorts jagged array by descending of sums of its rows elements.
        /// </summary>
        /// <param name="array">
        /// Jagged array for sorting.
        /// </param>
        public static void OrderBySumDescending(this int[][] array) =>
            BubbleSort(array, (a, b) => a.Sum() < b.Sum());

        /// <summary>
        /// Sorts jagged array by ascending of minimum element of its rows.
        /// </summary>
        /// <param name="array">
        /// Jagged array for sorting.
        /// </param>
        public static void OrderByMinElement(this int[][] array) =>
            BubbleSort(array, (a, b) => a.Min() > b.Min());

        /// <summary>
        /// Sorts jagged array by descending of minimum element of its rows.
        /// </summary>
        /// <param name="array">
        /// Jagged array for sorting.
        /// </param>
        public static void OrderByMinElementDescending(this int[][] array) =>
            BubbleSort(array, (a, b) => a.Min() < b.Min());

        /// <summary>
        /// Sorts jagged array by ascending of maximum element of its rows.
        /// </summary>
        /// <param name="array">
        /// Jagged array for sorting.
        /// </param>
        public static void OrderByMaxElement(this int[][] array) =>
            BubbleSort(array, (a, b) => a.Max() > b.Max());

        /// <summary>
        /// Sorts jagged array by descending of maximum element of its rows.
        /// </summary>
        /// <param name="array">
        /// Jagged array for sorting.
        /// </param>
        public static void OrderByMaxElementDescending(this int[][] array) =>
            BubbleSort(array, (a, b) => a.Max() < b.Max());

        /// <summary>
        /// Sorts passed jagged array using bubble sort.
        /// </summary>
        /// <param name="array">
        /// Jagged array for sorting.
        /// </param>
        /// <param name="sortingCriterion">
        /// Delegate which defines how rows will be sorted.
        /// Should return true if the first passed row
        /// should be placed righter than the second row.
        /// </param>
        private static void BubbleSort(int[][] array, Func<int[], int[], bool> sortingCriterion)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    throw new ArgumentNullException();
                }

                if (array[i].Length == 0)
                {
                    throw new ArgumentException();
                }
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 1; j < array.Length - i; j++)
                {
                    if (sortingCriterion(array[j - 1], array[j]))
                    {
                        int[] temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
