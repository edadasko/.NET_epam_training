using System;

namespace FindNextBiggerNumberTask
{
    public static class FindNextBiggerNumber
    {
        public static int Find(int num)
        {
            var strNum = num.ToString();

            var indexesForSwapping = FindOptimalChangingIndexes(strNum);

            if (indexesForSwapping == null)
                return -1;

            var numArray = strNum.ToCharArray();
            Swap(ref numArray[indexesForSwapping.Item1], ref numArray[indexesForSwapping.Item2]);
            Array.Sort(numArray, indexesForSwapping.Item1 + 1, numArray.Length - indexesForSwapping.Item1 - 1);
            return Convert.ToInt32(string.Join("", numArray));
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
