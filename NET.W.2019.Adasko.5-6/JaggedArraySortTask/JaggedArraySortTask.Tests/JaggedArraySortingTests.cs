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

            testArray.OrderBySum();

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

            testArray.OrderBySumDescending();

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

            testArray.OrderByMinElement();

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

            testArray.OrderByMinElementDescending();

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

            testArray.OrderByMaxElement();

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

            testArray.OrderByMaxElementDescending();

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

        /// <summary>
        /// Test some exceptions which can be thrown in sorting methods.
        /// </summary>
        [Test]
        public void OrderExceptionTest()
        {
            int[][] nullArray = null;
            Assert.Throws<ArgumentNullException>(() => nullArray.OrderByMaxElement());

            int[][] someRowsNullArray =
            {
                new int[] { 1, 2, 3 },
                null,
                new int[] { 1, 2, 3 },
            };

            Assert.Throws<ArgumentNullException>(() => someRowsNullArray.OrderByMaxElement());

            int[][] someRowsEmptyArray =
            {
                new int[] { 1, 2, 3 },
                new int[] { },
                new int[] { 1, 2, 3 },
            };

            Assert.Throws<ArgumentException>(() => someRowsEmptyArray.OrderByMaxElement());
        }

        /// <summary>
        /// Tests empty array sorting.
        /// </summary>
        [Test]
        public void EmptyArrayTest()
        {
            int[][] emptyArray = { };
            emptyArray.OrderByMaxElement();
            Assert.AreEqual(emptyArray, new int[][] { });
        }
    }
}