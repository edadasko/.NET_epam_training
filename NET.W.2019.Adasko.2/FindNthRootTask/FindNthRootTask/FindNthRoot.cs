using System;
using System.Text.RegularExpressions;

namespace FindNthRootTask
{
    public static class FindNthRoot
    {
        /// <summary>
        /// Finds root of Nth degree of passed num
        /// with given precision using Newton's method.
        /// </summary>
        /// <param name="num">
        /// The number from which the root will be calculated.
        /// </param>
        /// <param name="n">
        /// Root's degree.
        /// </param>
        /// <param name="precision">
        /// Precision for finding root.
        /// Should be in such format: "0.1", "0.00001"
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static double FindRoot(double num, int n, double precision)
        {
            if (n < 0 || (num < 0 && n % 2 == 0) || !IsPrecisionCorrect(precision))
                throw new ArgumentOutOfRangeException();

            double x, nextX = num;
            do
            {
                x = nextX;
                nextX = (double) 1 / n * ((n - 1) * x + num / Pow(x, n - 1));
            }
            while (Math.Abs(x - nextX) > precision);

            int roundNum = precision.ToString().Length - 2;

            return Math.Round(nextX, roundNum);
        }

        private static double Pow(double x, int n)
        {
            double answer = 1;
            for (int i = 0; i < n; i++)
                answer *= x;
            return answer;
        }

        private static bool IsPrecisionCorrect(double precision) =>
            Regex.IsMatch(((decimal)precision).ToString(), @"0\.0*1$");
    }
}
