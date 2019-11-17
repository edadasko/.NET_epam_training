using NUnit.Framework;
using FindNthRootTask;
using System;
namespace FindNthRootTest
{
    public class FindRootTests
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindRootTest(double num, int n, double precision) =>
            FindNthRoot.FindRoot(num, n, precision);

        [TestCase(8, 15, -7)]
        [TestCase(8, 15, -0.6)]
        [TestCase(-199, 2, 0.00001)]
        [TestCase(8, 6, 0.2323410)]
        public void FindRootExceptionTest(double num, int n, double precision)
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => FindNthRoot.FindRoot(num, n, precision));
        }
    }
}