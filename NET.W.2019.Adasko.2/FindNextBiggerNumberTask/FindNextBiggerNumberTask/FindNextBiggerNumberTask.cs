using System;
using System.Diagnostics;

namespace FindNextBiggerNumberTask
{
    public static class FindNextBiggerNumber
    {
        /// <summary>
        /// Finds the minimum number bigger than given
        /// that consists the same numbers in a different permutation.
        /// </summary>
        /// <returns>
        /// An answer if exist or -1 otherwise.
        /// </returns>
        public static long FindNextBiggerPermutation(int num)
        {
            var strNum = num.ToString();

            var indexesForSwapping = FindOptimalChangingIndexes(strNum);

            if (indexesForSwapping == null)
                return -1;

            var numArray = strNum.ToCharArray();
            Swap(ref numArray[indexesForSwapping.Item1], ref numArray[indexesForSwapping.Item2]);
            Array.Sort(numArray, indexesForSwapping.Item1 + 1, numArray.Length - indexesForSwapping.Item1 - 1);
            return Convert.ToInt64(string.Join("", numArray));
        }

        private static Tuple<int, int> FindOptimalChangingIndexes(string num)
        {
            for (int i = num.Length - 2; i >= 0; i--)
            {
                int nextBiggerDigit = FindNextBiggerDigit(i, num);
                if (nextBiggerDigit != -1)
                    return new Tuple<int, int>(i, nextBiggerDigit);
            }
            return null;
        }

        public static double MeasureTimeWithStopwatch(int num)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FindNextBiggerPermutation(num);
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static double MeasureTimeWithDateTime(int num)
        {
            DateTime start = DateTime.Now;
            FindNextBiggerPermutation(num);
            return (DateTime.Now - start).TotalMilliseconds;
        }

        private static void Swap(ref char a, ref char b)
        {
            char temp = a; a = b; b = temp;
        }

        private static int FindNextBiggerDigit(int index, string num)
        {
            int currentDigit = Convert.ToInt32(num[index]);
            int nextBiggerDigitIndex = -1;
            for (int i = index + 1; i < num.Length; i++)
            {
                int nextDigit = Convert.ToInt32(num[i]);
                if (nextDigit > currentDigit &&
                    (nextBiggerDigitIndex == -1 || nextDigit < num[nextBiggerDigitIndex]))
                    nextBiggerDigitIndex = i;
            }
            return nextBiggerDigitIndex;
               
        }
    }
}
