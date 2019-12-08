//-----------------------------------------------------------------------
// <copyright file="BooksFormatsTests.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------
namespace BooksFormatsTests
{
    using NUnit.Framework;
    using BooksTask;
    using System.Globalization;
    using System;

    /// <summary>
    /// Provides tests for string representations of books.
    /// </summary>
    public class BooksFormatsTests
    {
        /// <summary>
        /// IFormatProvider for converting book to string.
        /// </summary>
        private readonly IFormatProvider provider = CultureInfo.CreateSpecificCulture("en");

        /// <summary>
        /// Book to convert.
        /// </summary>
        private readonly Book book = new Book("978-0-7356-6754-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99M);

        /// <summary>
        /// Tests converting book to different formats.
        /// </summary>
        /// <param name="format">
        /// Format to convert.
        /// </param>
        /// <param name="expected">
        /// Expected result.
        /// </param>
        [TestCase("AT", "Jeffrey Richter, CLR via C#")]
        [TestCase("TY", "CLR via C#, 2012")]
        [TestCase("tc", "CLR via C#, $59.99")]
        [TestCase("AThY", "Jeffrey Richter, CLR via C#, Microsoft Press, 2012")]
        [TestCase("aTHyNC", "Jeffrey Richter, CLR via C#, Microsoft Press, 2012, P. 826, $59.99")]
        public void ToStringTest(string format, string expected)
        {
            string result = string.Format(provider, "{0:" + format + "}", book);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests throwing FormatException when wrong format was passed.
        /// </summary>
        [Test]
        public void ToStringFormatExceptionTest()
        {
            Assert.Throws<FormatException>(() => string.Format(provider, "{0: fewwfw}", book));
        }
    }
}