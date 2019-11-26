//---------------------------------------------------------
// <copyright file="PolynomialTests.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace PolynomialTask.Tests
{
    using System;
    using NUnit.Framework;
    using PolynomialTask;

    /// <summary>
    /// Class for testing operations with polynomials.
    /// </summary>
    public class PolynomialTests
    {
        /// <summary>
        /// Tests converting polynomial to string.
        /// </summary>
        [Test]
        public void PolynomialToStringTest()
        {
            Assert.AreEqual(new Polynomial(1, 2, 3, 4, 5).ToString(), "x^4 + 2x^3 + 3x^2 + 4x + 5");
            Assert.AreEqual(new Polynomial(-1, 2, -3, 4, -5).ToString(), "-x^4 + 2x^3 + -3x^2 + 4x + -5");
            Assert.AreEqual(new Polynomial(-1, 0, 0, 0, 5).ToString(), "-x^4 + 5");
            Assert.AreEqual(new Polynomial(5).ToString(), "5");
            Assert.AreEqual(new Polynomial(5, 0).ToString(), "5x");
            Assert.AreEqual(new Polynomial().ToString(), string.Empty);
        }

        /// <summary>
        /// Tests comparisons with polynomials.
        /// </summary>
        [Test]
        public void PolynomialAreEqualTest()
        {
            Assert.AreEqual(new Polynomial(1, 2, 3, 4, 5), new Polynomial(1, 2, 3, 4, 5));
            Assert.AreEqual(new Polynomial(), new Polynomial());
            Assert.AreNotEqual(new Polynomial(1, 2, 3, 4, 5), new Polynomial(1, 2, 3, 0, 5));
        }

        /// <summary>
        /// Tests GetHashCode method in Polynomial class.
        /// </summary>
        [Test]
        public void PolynomialGetHashCodeTest()
        {
            Assert.AreEqual(new Polynomial(1, 2, 3, 4, 5).GetHashCode(), new Polynomial(1, 2, 3, 4, 5).GetHashCode());
            Assert.AreNotEqual(new Polynomial(5, 2, 3, 4, 1).GetHashCode(), new Polynomial(5, 2, 3, 0, 1).GetHashCode());
        }

        /// <summary>
        /// Tests == operator with polynomials.
        /// </summary>
        [Test]
        public void PolynomialOperatorsEqualsTest()
        {
            Assert.IsTrue(new Polynomial(1) == 1);
            Assert.IsTrue(new Polynomial(100) == 100);
            Assert.IsTrue(new Polynomial(4) != 100);
        }

        /// <summary>
        /// Tests + operator with polynomials.
        /// </summary>
        [Test]
        public void PolynomialAdditionTest()
        {
            Assert.AreEqual(new Polynomial(1, 2, 3) + new Polynomial(3, 2, 1), new Polynomial(4, 4, 4));
            Assert.AreEqual(new Polynomial(1, 2, 3) + new Polynomial(-3, -2, -1), new Polynomial(-2, 0, 2));
            Assert.AreEqual(new Polynomial(1, 2, 3) + new Polynomial(1), new Polynomial(1, 2, 4));
            Assert.AreEqual(new Polynomial(1) + new Polynomial(1, 2, 3, 4, 5), new Polynomial(1, 2, 3, 4, 6));
            Assert.AreEqual(new Polynomial(1, 2, 3) + new Polynomial(-1, 2, 3), new Polynomial(4, 6));
            Assert.AreEqual(new Polynomial(1, 2, 3) + new Polynomial(-1, -2, 3), new Polynomial(6));
            Assert.AreEqual(new Polynomial(1, 2, 3) + new Polynomial(-1, -2, -3), new Polynomial());
            Assert.AreEqual(new Polynomial(1, 2, 3) + 10, new Polynomial(1, 2, 13));
            Assert.AreEqual(new Polynomial(-10) + 10, new Polynomial());
            Assert.AreEqual(100 + new Polynomial(), new Polynomial(100));
            Assert.AreEqual(new Polynomial(0) + new Polynomial(), new Polynomial());
            Assert.AreEqual(new Polynomial() + new Polynomial(), new Polynomial());
            Assert.AreEqual(new Polynomial(0, 0, 5) + new Polynomial(0, 5), new Polynomial(10));
        }

        /// <summary>
        /// Tests - operator with polynomials.
        /// </summary>
        [Test]
        public void PolynomialSubtractionTest()
        {
            Assert.AreEqual(new Polynomial(1, 2, 3) - new Polynomial(3, 2, 1), new Polynomial(-2, 0, 2));
            Assert.AreEqual(new Polynomial(1, 2, 3) - new Polynomial(1, 0, 0), new Polynomial(2, 3));
            Assert.AreEqual(new Polynomial(1, 2, 3) - 5, new Polynomial(1, 2, -2));
            Assert.AreEqual(5 - new Polynomial(1, 2, 3), new Polynomial(-1, -2, 2));
        }

        /// <summary>
        /// Tests * operator with polynomials.
        /// </summary>
        [Test]
        public void PolynomialMultiplicationTest()
        {
            Assert.AreEqual(new Polynomial(2, 1, 0) * new Polynomial(1, 2, 3), new Polynomial(2, 5, 8, 3, 0));
            Assert.AreEqual(new Polynomial(2, 1, 0) * 5, new Polynomial(10, 5, 0));
            Assert.AreEqual(new Polynomial(2, 1, 0) * 0, new Polynomial());
            Assert.AreEqual(new Polynomial(2, 1, 0) * new Polynomial(), new Polynomial());
            Assert.AreEqual(new Polynomial(3, 7) * new Polynomial(1, 2), new Polynomial(3, 13, 14));
        }

        /// <summary>
        /// Tests / operator with polynomials.
        /// </summary>
        [Test]
        public void PolynomialDivisionTest()
        {
            Assert.AreEqual(new Polynomial(10, 15, 5) / 5, new Polynomial(2, 3, 1));
            var p = new Polynomial(10, 15, 5);
            Assert.Throws<DivideByZeroException>(() => { var a = p / 0; });
        }
    }
}