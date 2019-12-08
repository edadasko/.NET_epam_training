//-----------------------------------------------------------------------
// <copyright file="JaggedArraySorting.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace JaggedArraySortTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides extension methods for sorting
    /// jagged arrays with different sorting criterions.
    /// </summary>
    public static class JaggedArraySorting
    {
        /// <summary>
        /// Sorts passed jagged array using bubble sort.
        /// </summary>
        /// <param name="array">
        /// Jagged array for sorting.
        /// </param>
        /// <param name="comparer">
        /// Interface which provides compare method for sorting.
        /// </param>
        public static void BubbleSort(this int[][] array, IComparer<int[]> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException();
            }

            array.BubbleSort(comparer.Compare);
        }

        /// <summary>
        /// Sorts passed jagged array using bubble sort.
        /// </summary>
        /// <param name="array">
        /// Jagged array for sorting.
        /// </param>
        /// <param name="sortingCriterion">
        /// Delegate which defines how rows will be sorted.
        /// Should return 1 if the first passed row
        /// should be placed righter than the second row.
        /// 0 if they are equals.
        /// -1 otherwise.
        /// </param>
        public static void BubbleSort(this int[][] array, Func<int[], int[], int> sortingCriterion)
        {
            if (array == null || sortingCriterion == null)
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
                    if (sortingCriterion(array[j - 1], array[j]) > 0)
                    {
                        int[] temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }

    #region Comparer Classes
    /// <summary>
    /// Provides implementation of compare method for sorting jagged array by ascending of sum of each row.
    /// </summary>
    public class SumComparer : IComparer<int[]>
    {
        /// <inheritdoc/>
        public int Compare(int[] x, int[] y) => x.Sum().CompareTo(y.Sum());
    }

    /// <summary>
    /// Provides implementation of compare method for sorting jagged array by descending of sum of each row .
    /// </summary>
    public class SumDescendingComparer : IComparer<int[]>
    {
        /// <inheritdoc/>
        public int Compare(int[] x, int[] y) => y.Sum().CompareTo(x.Sum());
    }

    /// <summary>
    /// Provides implementation of compare method for sorting jagged array by ascending of max element of each row.
    /// </summary>
    public class MaxComparer : IComparer<int[]>
    {
        /// <inheritdoc/>
        public int Compare(int[] x, int[] y) => x.Max().CompareTo(y.Max());
    }

    /// <summary>
    /// Provides implementation of compare method for sorting jagged array by descending of max element of each row .
    /// </summary>
    public class MaxDescendingComparer : IComparer<int[]>
    {
        /// <inheritdoc/>
        public int Compare(int[] x, int[] y) => y.Max().CompareTo(x.Max());
    }

    /// <summary>
    /// Provides implementation of compare method for sorting jagged array by ascending of min element of each row.
    /// </summary>
    public class MinComparer : IComparer<int[]>
    {
        /// <inheritdoc/>
        public int Compare(int[] x, int[] y) => x.Min().CompareTo(y.Min());
    }

    /// <summary>
    /// Provides implementation of compare method for sorting jagged array by descending of min element of each row .
    /// </summary>
    public class MinDescendingComparer : IComparer<int[]>
    {
        /// <inheritdoc/>
        public int Compare(int[] x, int[] y) => y.Min().CompareTo(x.Max());
    }

    #endregion
}
