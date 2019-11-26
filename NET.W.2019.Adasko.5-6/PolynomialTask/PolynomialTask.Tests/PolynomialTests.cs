using NUnit.Framework;
using PolynomialTask;
namespace PolynomialTask.Tests
{
    public class PolynomialTests
    {
        [Test]
        public void PolynomialToStringTest()
        {
            Assert.AreEqual(new Polynomial(1, 2, 3, 4, 5).ToString(), "x^4 + 2x^3 + 3x^2 + 4x + 5");
            Assert.AreEqual(new Polynomial(-1, 2, -3, 4, -5).ToString(), "-x^4 + 2x^3 + -3x^2 + 4x + -5");
            Assert.AreEqual(new Polynomial(-1, 0, 0, 0, 5).ToString(), "-x^4 + 5");
            Assert.AreEqual(new Polynomial(5).ToString(), "5");
            Assert.AreEqual(new Polynomial(5, 0).ToString(), "5x");
        }

        [Test]
        public void PolynomialAreEqualTest()
        {
            Assert.AreEqual(new Polynomial(1, 2, 3, 4, 5), new Polynomial(1, 2, 3, 4, 5));
            Assert.AreNotEqual(new Polynomial(1, 2, 3, 4, 5), new Polynomial(1, 2, 3, 0, 5));
        }

        [Test]
        public void PolynomialGetHashCodeTest()
        {
            Assert.AreEqual(new Polynomial(1, 2, 3, 4, 5).GetHashCode(), new Polynomial(1, 2, 3, 4, 5).GetHashCode());
            Assert.AreNotEqual(new Polynomial(5, 2, 3, 4, 1).GetHashCode(), new Polynomial(5, 2, 3, 0, 1).GetHashCode());
        }
    }
}