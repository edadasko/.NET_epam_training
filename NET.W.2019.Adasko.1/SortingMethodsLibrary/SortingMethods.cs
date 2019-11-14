using System;
using System.Linq;
namespace SortingMethodsLibrary
{
	public static class SortingMethods
	{
        /// <summary>
        /// Quick Sort implementation using Lomuto partition scheme.
        /// Time complexity:
        /// Worst-case: O(n^2).
        /// Best-case: O(n*log(n)).
        /// Average: O(n*log(n)).
        /// </summary>
        /// <param name="array">Unsorted array.</param>
        public static void QuickSort(this int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            QuickSort(array, 0, array.Length);
        }

		private static void QuickSort(int[] array, int begin, int end)
		{
			if (!array.Any() || begin >= end - 1)
				return;

			static void Swap(ref int a, ref int b)
			{
				int temp = a; a = b; b = temp;
			}

			int pivot = array[end - 1];
			int middleIndex = begin;

			for (int i = begin; i < end - 1; i++)
			{
				if (array[i] < pivot)
				{
					Swap(ref array[i], ref array[middleIndex]);
					middleIndex++;
				}
			}

			Swap(ref array[end - 1], ref array[middleIndex]);

			QuickSort(array, begin, middleIndex);
			QuickSort(array, middleIndex + 1, end);
		}


		/// <summary>
		/// Merge Sort implementation.
		/// Time complexity:
		/// Worst-case: O(n*log(n)).
		/// Best-case: O(n*log(n)).
		/// Average: O(n*log(n)).
		/// </summary>
		/// <param name="array">Unsorted array.</param>
		public static void MergeSort(this int[] array)
		{
            if (array == null)
                throw new ArgumentNullException();

            MergeSort(array, 0, array.Length).CopyTo(array, 0);
		}

		private static int[] MergeSort(int[] array, int begin, int end)
		{
			static int[] Merge(int[] left, int[] right)
			{
			    int[] result = new int[left.Length + right.Length];

				int leftIndex = 0;
				int rightIndex = 0;
			    int resultIndex = 0;

				while (leftIndex < left.Length && rightIndex < right.Length)
				{
					if (left[leftIndex] < right[rightIndex])
					{
						result[resultIndex] = left[leftIndex];
						leftIndex++;
					}
					else
					{
						result[resultIndex] = right[rightIndex];
						rightIndex++;
					}
					resultIndex++;
				}

				if (leftIndex == left.Length)
					for (int i = rightIndex; i < right.Length; i++, resultIndex++)
						result[resultIndex] = right[i];
				else
					for (int i = leftIndex; i < left.Length; i++, resultIndex++)
						result[resultIndex] = left[i];

				return result;
			}

            if (!array.Any())
                return new int[0];

		    if (begin == end - 1)
			    return new int[] { array[begin] };

			int middle = (begin + end) / 2;
			int[] left = MergeSort(array, begin, middle);
			int[] right = MergeSort(array, middle, end);
			return Merge(left, right);
		}
	}
}