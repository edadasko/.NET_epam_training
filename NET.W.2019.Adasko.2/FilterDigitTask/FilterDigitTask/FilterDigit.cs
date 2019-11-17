using System;
using System.Collections.Generic;

namespace FilterDigitTask
{
    public static class FilterDigit
    {
        /// <summary>
        /// Filters passed list of integers.
        /// The list of integers contains passed digit is obtained.
        /// </summary>
        /// <param name="list">
        /// The list for filtering.
        /// </param>
        /// <param name="filterDigit">
        /// The digit which all of resulting integers should contain.
        /// </param>
        /// <returns>
        /// Filtered list, elements of which contain passed digit.
        /// </returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static List<int> Filter(List<int> list, int filterDigit)
        {
            if (list == null)
                throw new ArgumentNullException();

            if (filterDigit > 9 || filterDigit < 0)
                throw new ArgumentOutOfRangeException();

            var answer = new List<int>();

            foreach (var num in list)
                if (num.ConsistsDigit(filterDigit))
                    answer.Add(num);

            return answer;
        }

        private static bool ConsistsDigit(this int num, int digit)
        {
            var strNum = num.ToString();
            foreach (var digitToCompare in strNum)
                if ((int)char.GetNumericValue(digitToCompare) == digit)
                    return true;

            return false;
        }
    }
}
