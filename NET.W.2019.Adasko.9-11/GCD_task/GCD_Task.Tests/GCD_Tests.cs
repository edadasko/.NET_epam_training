//-----------------------------------------------------------------------
// <copyright file="GCD_Tests.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace GCD_Task.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Provides tests for GCD class.
    /// </summary>
    public class GCD_Tests
    {
        /// <summary>
        /// Tests Euclid algorithm with 2 numbers.
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
        [TestCase(48, 18, ExpectedResult = 6)]
        [TestCase(2, 4, ExpectedResult = 2)]
        [TestCase(1002017, 1000133, ExpectedResult = 1)]
        [TestCase(325877, 20003149, ExpectedResult = 1)]
        [TestCase(144, 12, ExpectedResult = 12)]
        [TestCase(1000000, 0, ExpectedResult = 1000000)]
        [TestCase(-48, -18, ExpectedResult = 6)]
        [TestCase(2932893, 3584647, ExpectedResult = 325877)]
        public int EuclidAlgotithm_2numbersTest(int num1, int num2) =>
            GCD.EuclidAlgotithm(num1, num2);

        /// <summary>
        /// Tests Stein algorithm with 2 numbers.
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
        [TestCase(48, 18, ExpectedResult = 6)]
        [TestCase(2, 4, ExpectedResult = 2)]
        [TestCase(1002017, 1000133, ExpectedResult = 1)]
        [TestCase(325877, 20003149, ExpectedResult = 1)]
        [TestCase(144, 12, ExpectedResult = 12)]
        [TestCase(1000000, 0, ExpectedResult = 1000000)]
        [TestCase(-48, -18, ExpectedResult = 6)]
        [TestCase(2932893, 3584647, ExpectedResult = 325877)]
        public int SteinAlgotithm_2numbersTest(int num1, int num2) =>
            GCD.SteinAlgotithm(num1, num2);

        /// <summary>
        /// Tests Euclid algorithm with 3 numbers.
        /// </summary>
        /// <param name="num1">
        /// First number.
        /// </param>
        /// <param name="num2">
        /// Second number.
        /// </param>
        /// <param name="num3">
        /// Third number.
        /// </param>
        /// <returns>
        /// GCD of passed numbers.
        /// </returns>
        [TestCase(-48, 18, -6, ExpectedResult = 6)]
        [TestCase(6, 18, 48, ExpectedResult = 6)]
        [TestCase(102, 4, 16, ExpectedResult = 2)]
        [TestCase(0, 25, 100, ExpectedResult = 25)]
        [TestCase(2932893, 3584647, 651754, ExpectedResult = 325877)]
        public int EuclidAlgotithm_3numbersTest(int num1, int num2, int num3) =>
            GCD.EuclidAlgotithm(num1, num2, num3);

        /// <summary>
        /// Tests Stein algorithm with 3 numbers.
        /// </summary>
        /// <param name="num1">
        /// First number.
        /// </param>
        /// <param name="num2">
        /// Second number.
        /// </param>
        /// <param name="num3">
        /// Third number.
        /// </param>
        /// <returns>
        /// GCD of passed numbers.
        /// </returns>
        [TestCase(-48, 18, -6, ExpectedResult = 6)]
        [TestCase(6, 18, 48, ExpectedResult = 6)]
        [TestCase(102, 4, 16, ExpectedResult = 2)]
        [TestCase(0, 25, 100, ExpectedResult = 25)]
        [TestCase(2932893, 3584647, 651754, ExpectedResult = 325877)]
        public int SteinAlgotithm_3numbersTest(int num1, int num2, int num3) =>
            GCD.EuclidAlgotithm(num1, num2, num3);

        /// <summary>
        /// Tests throwing ArgumentException in Euclid Algoritms.
        /// </summary>
        [Test]
        public void EuclidAlgotithm_ArgumentExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => GCD.EuclidAlgotithm(0));
            Assert.Throws<ArgumentException>(() => GCD.EuclidAlgotithm(5));
        }

        /// <summary>
        /// Tests throwing ArgumentException in Stein Algoritms.
        /// </summary>
        [Test]
        public void SteinAlgotithm_ArgumentExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => GCD.SteinAlgotithm(0));
            Assert.Throws<ArgumentException>(() => GCD.SteinAlgotithm(5));
        }

        /// <summary>
        /// Tests that Stein Algoritm is faster than Euclid Algorithm.
        /// </summary>
        /// <param name="num1">
        /// First num.
        /// </param>
        /// <param name="num2">
        /// Second num.
        /// </param>
        [TestCase(2932893, 3584647)]
        [TestCase(2, 4)]
        public void TimeMeasureTest(int num1, int num2)
        {
            Assert.IsTrue(GCD.TimeMeasure(GCD.EuclidAlgotithm, num1, num2)
                > GCD.TimeMeasure(GCD.SteinAlgotithm, num1, num2));
        }
    }
}