namespace JaggedArraySortTask.Tests
{
    using System;
    using NUnit.Framework;

    public class JaggedArraySortTests
    {
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

        [Test]
        public void OrderBySumDescedingTest()
        {
            var testArray =
                new int[][]
                {
                    new int[] { 7 },
                    new int[] { 1, 2 },
                    new int[] { 100, 100, 100 },
                    new int[] { -1, -5, -10 },
                };

            testArray.OrderBySumDesceding();

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

        [Test]
        public void OrderByMinElementDescedingTest()
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

            testArray.OrderByMinElementDesceding();

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

        [Test]
        public void OrderByMaxElementDescedingTest()
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

            testArray.OrderByMaxElementDesceding();

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

        [Test]
        public void EmptyArrayTest()
        {
            int[][] emptyArray = { };
            emptyArray.OrderByMaxElement();
            Assert.AreEqual(emptyArray, new int[][] { });
        }
    }
}