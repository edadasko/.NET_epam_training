//-----------------------------------------------------------------------
// <copyright file="MatricesTests.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace MatricesTests
{
    using System;
    using MatricesTask;
    using NUnit.Framework;

    /// <summary>
    /// Tests matrices classes.
    /// </summary>
    public class MatricesTests
    {
        private Matrix<int> a = new Matrix<int>(new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
        });

        private Matrix<int> b = new Matrix<int>(new int[,]
        {
            { 2, 4, 6 },
            { 8, 10, 12 },
            { 14, 16, 18 }
        });

        private Matrix<string> s = new Matrix<string>(new string[,]
        {
            { "1", "2", "3" },
            { "4", "5", "6" },
            { "7", "8", "9" },
        });

        private Matrix<string> ss = new Matrix<string>(new string[,]
        {
            { "11", "22", "33" },
            { "44", "55", "66" },
            { "77", "88", "99" },
        });

        private int[,] symmetric =
        {
            { 1, 2, 3 },
            { 2, 5, 6 },
            { 3, 6, 9 },
        };

        private int[,] diagonal =
        {
            { 1, 0, 0 },
            { 0, 5, 0 },
            { 0, 0, 9 },
        };

        private int[,] notSquare =
        {
            { 1, 0 },
            { 0, 5 },
            { 0, 0 },
        };


        [Test]
        public void IntMatricesAdditionTest()
        {
            var sum = this.a.Add(this.a);
            Assert.AreEqual(sum, this.b);
        }

        [Test]
        public void StringMatricesAdditionTest()
        {
            var sum = this.s.Add(this.s);
            Assert.AreEqual(sum, this.ss);
        }

        [Test]
        public void CreationMatricesTest()
        {
            Assert.DoesNotThrow(() => new SymmetricMatrix<int>(this.symmetric));
            Assert.DoesNotThrow(() => new DiagonalMatrix<int>(this.diagonal));
            Assert.DoesNotThrow(() => new SquareMatrix<int>(this.symmetric));
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(this.notSquare));
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<int>(this.symmetric));
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<int>(this.notSquare));
        }
    }
}