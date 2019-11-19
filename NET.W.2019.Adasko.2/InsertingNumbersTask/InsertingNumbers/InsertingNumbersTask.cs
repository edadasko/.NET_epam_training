using System;

namespace InsertingNumbers
{
    public static class InsertingNumbersTask
    {
        private const int NumOfBits = 32;
        private const uint Mask = uint.MaxValue;

        /// <summary>
        /// Inserts bits of one integer number to another.
        /// Segment of [i, j] bits of the first number will be replaced
        /// by the first (j - i + 1) bits of the second number.
        /// Numbers of bits for inserting should be passed as parameters.
        /// </summary>
        /// <param name="targetNum">
        /// The number in which you want insert bits of another number.
        /// </param>
        /// <param name="insertNum">
        /// The number which provides bits for inserting.
        /// </param>
        /// <param name="i">
        /// The first index of segment for inserting of targetNum.
        /// </param>
        /// <param name="j">
        /// The last index of segment for inserting of targetNum.
        /// </param>
        /// <exception cref="OverflowException">
        /// Thrown when the resulting number contains 32 '1' bits.
        /// This number does not fit in integer range.
        /// </exception>
        /// /// <exception cref="ArgumentException">
        /// Thrown when passed indexes are incorrect.
        /// </exception>
        public static int InsertNumber(int targetNum, int insertNum, int i, int j)
        {
            if (i > j || i < 0 || j < 0 || i > NumOfBits - 1 || j > NumOfBits - 1)
            {
                throw new ArgumentException();
            }

            uint maskForInsertNum = Mask >> (NumOfBits - 1 - j);
            insertNum = (int)((insertNum << i) & maskForInsertNum);

            uint maskForTargetNum = (Mask << j) | (Mask >> (NumOfBits - 1 - i));
            targetNum = (int)(maskForTargetNum & targetNum);

            if ((uint)(insertNum | targetNum) == uint.MaxValue)
            {
                throw new OverflowException();
            }

            return insertNum | targetNum;
        }
    }
}
