//-----------------------------------------------------------------------
// <copyright file="BookCustomFormatting.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Provides additional facilities in formatting books.
    /// </summary>
    public class BookCustomFormatting : ICustomFormatter, IFormatProvider
    {
        /// <summary>
        /// Culture for string representation.
        /// </summary>
        private readonly CultureInfo culture;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookCustomFormatting"/> class.
        /// </summary>
        /// <param name="culture">
        /// Culture info object.
        /// </param>
        public BookCustomFormatting(CultureInfo culture)
        {
            this.culture = culture;
        }

        /// <inheritdoc />
        public string Format(string format, object arg, IFormatProvider provider)
        {
            if (arg is Book book)
            {
                return this.GetFormat(format, book, this.culture);
            }

            return null;
        }

        /// <inheritdoc />
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        /// <summary>
        /// Help method for Format method.
        /// </summary>
        /// <param name="format">
        /// Format parameters.
        /// </param>
        /// <param name="book">
        /// Book to formatting.
        /// </param>
        /// <param name="provider">
        /// Culture features.
        /// </param>
        /// <returns>
        /// String representation of object.
        /// </returns>
        private string GetFormat(string format, Book book, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentException();
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            return (format.ToUpper()) switch
            {
                "FULL" => book.ToString("ATHYNCI", provider),
                "SHORT" => book.ToString("ATY", provider),
                _ => throw new FormatException(),
            };
        }
    }
}
