using InsertingNumbers;
using NUnit.Framework;

namespace InsertingNumbersTest
{
    public class InsertingNUnitTests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]

        [TestCase(0b00010000_00101100_11110001_10000111,
                  0b00000000_00000000_11000011_10000011, 24, 31,
                  ExpectedResult =
                  unchecked((int)
                  0b10000011_00101100_11110001_10000111))]

        [TestCase(0b00010000_00101100_11110001_10000111,
                  unchecked((int)
                  0b10000000_00000000_11000011_10000011), 0, 31,
                  ExpectedResult =
                  unchecked((int)
                  0b10000000_00000000_11000011_10000011))]

        [TestCase(0b00010000_00101100_11110001_10000111,
                  unchecked((int)
                  0b10000000_00000000_11000011_10000011), 0, 31,
                  ExpectedResult =
                  unchecked((int)
                  0b10000000_00000000_11000011_10000011))]

        [TestCase(unchecked((int)0b11110000_00101100_11110001_10000111),
                  unchecked((int)0b10011000_11111000_10100011_10111011), 6, 24,
                  ExpectedResult =
                  unchecked((int)0b11110000_00101000_11101110_11000111))]

        public long InsertTests(int target, int insert, int i, int j) =>
            InsertingNumbersTask.InsertNumber(target, insert, i, j);

        [Test]
        public void InsertExceptionTest()
        {
            Assert.Throws<System.OverflowException>(() =>
                InsertingNumbersTask.InsertNumber(
                    0b00000000_00000000_11111111_11111111,
                    0b00000000_00000000_11111111_11111111, 16, 31));
        }
            
    }
}