namespace JaggedArraySortTask
{
    using System;
    using System.Linq;

    public static class JaggedArraySorting
    {
        public static void OrderBySum(this int[][] array) =>
            Sort(array, (a, b) => a.Sum() > b.Sum());

        public static void OrderBySumDesceding(this int[][] array) =>
            Sort(array, (a, b) => a.Sum() < b.Sum());

        public static void OrderByMinElement(this int[][] array) =>
            Sort(array, (a, b) => a.Min() > b.Min());

        public static void OrderByMinElementDesceding(this int[][] array) =>
            Sort(array, (a, b) => a.Min() < b.Min());

        public static void OrderByMaxElement(this int[][] array) =>
            Sort(array, (a, b) => a.Max() > b.Max());

        public static void OrderByMaxElementDesceding(this int[][] array) =>
            Sort(array, (a, b) => a.Max() < b.Max());

        private static void Sort(int[][] array, Func<int[], int[], bool> sortingCriterion)
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
