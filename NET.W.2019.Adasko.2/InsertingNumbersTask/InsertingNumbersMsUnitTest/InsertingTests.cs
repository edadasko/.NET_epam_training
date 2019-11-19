using System;
using InsertingNumbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsertingNumbersMsUnitTest
{
    [TestClass]
    public class InsertingMsUnitTests
    {
        [TestMethod]
        public void ExceptionTest()
        {
            Assert.ThrowsException<OverflowException>(
                () => InsertingNumbersTask.InsertNumber(
                    0b00000000_00000000_11111111_11111111,
                    0b00000000_00000000_11111111_11111111,
                    16,
                    31));
        }

        [TestMethod]
        public void InsertTest()
        {
            Assert.AreEqual(InsertingNumbersTask.InsertNumber(15, 15, 0, 0), 15);
            Assert.AreEqual(InsertingNumbersTask.InsertNumber(8, 15, 0, 0), 9);
            Assert.AreEqual(InsertingNumbersTask.InsertNumber(8, 15, 3, 8), 120);
        }
    }
}
