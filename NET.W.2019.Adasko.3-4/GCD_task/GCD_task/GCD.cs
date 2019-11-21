//-----------------------------------------------------------------------
// <copyright file="GCD.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace GCD_Task
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Provides methods for finding Greatest Common Divisions of some numbers.
    /// </summary>
    public static class GCD
    {
        /// <summary>
        /// Finds GCD of some numbers using Euclid Algorithm.
        /// </summary>
        /// <param name="nums">
        /// Numbers for finding GCD.
        /// </param>
        /// <returns>
        /// GCD of passed numbers.
        /// </returns>
        public static int EuclidAlgotithm(params int[] nums)
            => ArrayGCD(nums, EuclidAlgotithm);

        /// <summary>
        /// Finds GCD of some numbers using Stein Algorithm.
        /// </summary>
        /// <param name="nums">
        /// Numbers for finding GCD.
        /// </param>
        /// <returns>
        /// GCD of passed numbers.
        /// </returns>
        public static int SteinAlgotithm(params int[] nums)
            => ArrayGCD(nums, SteinAlgotithm);

        /// <summary>
        /// Measures time of finding GCD.
        /// </summary>
        /// <param name="method">
        /// Method which is used in finding GCD.
        /// </param>
        /// <param name="nums">
        /// Numbers for finding GCD.
        /// </param>
        /// <returns>
        /// Time in milliseconds.
        /// </returns>
        public static double TimeMeasure(Func<int[], int> method, params int[] nums)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            method(nums);
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Finds GCD of array of numbers using passed method algorithm.
        /// </summary>
        /// <param name="nums">
        /// Numbers for finding GCD.
        /// </param>
        /// <param name="method">
        /// Method which is used in finding GCD.
        /// </param>
        /// <returns>
        /// GCD of passed array.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws when array contains less than 2 numbers.
        /// </exception>
        private static int ArrayGCD(int[] nums, Func<int, int, int> method)
        {
            if (nums.Length < 2)
            {
                throw new ArgumentException();
            }

            int gcd = method(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                gcd = method(gcd, nums[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Finds GCD of 2 numbers using Euclid Algotithm.
        /// </summary>
        /// <param name="num1">
        /// First number.
        /// </param>
        /// <param name="num2">
        /// Second number.
        /// </param>
        /// <returns>
        /// GCD of passed numbers.
        /// </returns>
        private static int EuclidAlgotithm(int num1, int num2)
        {
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);

            int temp;

            while (num2 != 0)
            {
                temp = num2;
                num2 = num1 % num2;
                num1 = temp;
            }

            return num1;
        }

        /// <summary>
        /// Finds GCD of 2 numbers using Stein Algotithm.
        /// </summary>
        /// <param name="num1">
        /// First number.
        /// </param>
        /// <param name="num2">
        /// Second number.
        /// </param>
        /// <returns>
        /// GCD of passed numbers.
        /// </returns>
        private static int SteinAlgotithm(int num1, int num2)
        {
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);

            int shift;
            if (num1 == 0)
            {
                return num2;
            }

            if (num2 == 0)
            {
                return num1;
            }

            for (shift = 0; ((num1 | num2) & 1) == 0; shift++)
            {
                num1 >>= 1;
                num2 >>= 1;
            }

            while ((num1 & 1) == 0)
            {
                num1 >>= 1;
            }

            do
            {
                while ((num2 & 1) == 0)
                {
                    num2 >>= 1;
                }

                if (num1 > num2)
                {
                    int temp = num2;
                    num2 = num1;
                    num1 = temp;
                }

                num2 -= num1;
            }
            while (num2 != 0);

            return num1 << shift;
        }
    }
}
