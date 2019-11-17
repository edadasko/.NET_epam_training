using NUnit.Framework;
using FilterDigitTask;
using System.Collections.Generic;
using System;
using System.Collections;

namespace FilterDigitTest
{
    public class FilterTests
    {
        private static readonly object[] filterTestCases =
            {
            new TestCaseData(new List<int> { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}, 7)
                    .Returns(new List<int> { 7, 70, 17 }),
            new TestCaseData(new List<int> { 100, 0, 12232, 23323, 4342, 3443111 }, 1)
                    .Returns(new List<int> { 100, 12232, 3443111 }),
            new TestCaseData(new List<int> { 100, 0, 12232, 23323, 4342, 3443111 }, 9)
                    .Returns(new List<int> { }),
            new TestCaseData(new List<int> { }, 9)
                    .Returns(new List<int> { })
        };

        [Test, TestCaseSource("filterTestCases")]
        public List<int> FilterTest(List<int> list, int digit) => FilterDigit.Filter(list, digit);

        [Test]
        public void FilterExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => FilterDigit.Filter(null, 9));
            Assert.Throws<ArgumentOutOfRangeException>(() => FilterDigit.Filter(new List<int>{ }, -12));
            Assert.Throws<ArgumentOutOfRangeException>(() => FilterDigit.Filter(new List<int> { }, 100));
        } 
    }
}