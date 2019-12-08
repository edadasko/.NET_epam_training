//-----------------------------------------------------------------------
// <copyright file="JaggedArraySortingTests.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace JaggedArraySortTask.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Provides tests for JaggedArraySorting class.
    /// </summary>
    public class JaggedArraySortingTests
    {
        /// <summary>
        /// Tests jagged array sorting by ascending of sums of rows elements.
        /// </summary>
        [Test]
        public void OrderBySumTest()
        {
            var testArray =
                new int[][]
                {
                    new int[] { 7 },
                    new int[] { 1, 2 },
                    new int[] { 100, 100, 100 },
                    new int[] { -1, -5, -10 },
                };

            testArray.BubbleSort(new SumComparer());

            Assert.AreEqual(
                new int[][]
                {
                    new int[] { -1, -5, -10 },
                    new int[] { 1, 2 },
                    new int[] { 7 },
                    new int[] { 100, 100, 100 },
                },
                testArray);
        }

        /// <summary>
        /// Tests jagged array sorting by descending of sums of rows elements.
        /// </summary>
        [Test]
        public void OrderBySumDescendingTest()
        {
            var testArray =
                new int[][]
                {
                    new int[] { 7 },
                    new int[] { 1, 2 },
                    new int[] { 100, 100, 100 },
                    new int[] { -1, -5, -10 },
                };

            testArray.BubbleSort(new SumDescendingComparer());

            Assert.AreEqual(
                new int[][]
                {
                    new int[] { 100, 100, 100 },
                    new int[] { 7 },
                    new int[] { 1, 2 },
                    new int[] { -1, -5, -10 },
                },
                testArray);
        }

        /// <summary>
        /// Tests jagged array sorting by ascending of minimum element of its rows.
        /// </summary>
        [Test]
        public void OrderByMinElementTest()
        {
            var testArray =
                new int[][]
                {
                    new int[] { 3 },
                    new int[] { 1, 2 },
                    new int[] { 100, 100, 100 },
                    new int[] { -1, -5, -10 },
                    new int[] { -100, 5, 10 },
                };

            testArray.BubbleSort(new MinComparer());

            Assert.AreEqual(
                new int[][]
                {
                    new int[] { -100, 5, 10 },
                    new int[] { -1, -5, -10 },
                    new int[] { 1, 2 },
                    new int[] { 3 },
                    new int[] { 100, 100, 100 },
                },
                testArray);
        }

        /// <summary>
        /// Tests jagged array sorting by descending of minimum element of its rows.
        /// </summary>
        [Test]
        public void OrderByMinElementDescendingTest()
        {
            var testArray =
                new int[][]
                {
                    new int[] { 3 },
                    new int[] { 1, 2 },
                    new int[] { 100, 100, 100 },
                    new int[] { -1, -5, -10 },
                    new int[] { 5, 10, -100 },
                };

            testArray.BubbleSort(new MinDescendingComparer());

            Assert.AreEqual(
                new int[][]
                {
                    new int[] { 100, 100, 100 },
                    new int[] { 3 },
                    new int[] { 1, 2 },
                    new int[] { -1, -5, -10 },
                    new int[] { 5, 10, -100 },
                },
                testArray);
        }

        /// <summary>
        /// Tests jagged array sorting by ascending of maximum element of its rows.
        /// </summary>
        [Test]
        public void OrderByMaxElementTest()
        {
            var testArray =
                new int[][]
                {
                    new int[] { 3 },
                    new int[] { 1, 2 },
                    new int[] { 100, 100, 100 },
                    new int[] { -1, -5, -10 },
                    new int[] { -100, 5, 10 }
                };

            testArray.BubbleSort(new MaxComparer());

            Assert.AreEqual(
                new int[][]
                {
                    new int[] { -1, -5, -10 },
                    new int[] { 1, 2 },
                    new int[] { 3 },
                    new int[] { -100, 5, 10 },
                    new int[] { 100, 100, 100 },
                },
                testArray);
        }

        /// <summary>
        /// Tests jagged array sorting by descending of maximum element of its rows.
        /// </summary>
        [Test]
        public void OrderByMaxElementDescendingTest()
        {
            var testArray =
                new int[][]
                {
                    new int[] { 3 },
                    new int[] { 1, 2 },
                    new int[] { 100, 100, 100 },
                    new int[] { -1, -5, -10 },
                    new int[] { -100, 5, 10 }
                };

            testArray.BubbleSort(new MaxDescendingComparer());

            Assert.AreEqual(
                new int[][]
                {
                    new int[] { 100, 100, 100 },
                    new int[] { -100, 5, 10 },
                    new int[] { 3 },
                    new int[] { 1, 2 },
                    new int[] { -1, -5, -10 },
                },
                testArray);
        }
    }
}