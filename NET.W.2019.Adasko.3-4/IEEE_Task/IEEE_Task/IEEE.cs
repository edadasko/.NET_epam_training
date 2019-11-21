//-----------------------------------------------------------------------
// <copyright file="IEEE.cs" company="Epam">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace IEEE_Task
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Provides method for converting double value to IEEE representation.
    /// </summary>
    public static class IEEE
    {
        /// <summary>
        /// Num of bits in double value.
        /// </summary>
        private const int NumOfBits = 64;

        /// <summary>
        /// Converts passed double value to its IEEE representation. 
        /// </summary>
        /// <param name="number">
        /// Double value for converting.
        /// </param>
        /// <returns>
        /// String IEEE representation of passed value.
        /// </returns>
        public static string ConvertToIEEE(this double number)
        {
            string doubleIEEE = string.Empty;
            long longRepresentation = new DoubleLong(number).LongValue;
            for (int i = 0; i < NumOfBits; i++)
            {
                doubleIEEE += (longRepresentation & 1) == 1 ? "1" : "0";
                longRepresentation >>= 1;
            }

            return new string(doubleIEEE.Reverse().ToArray());
        }

        /// <summary>
        /// Helps to get long representation of double number with same bits
        /// for using number in binary operations.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleLong
        {
            /// <summary>
            /// Long representation of passed value.
            /// </summary>
            [FieldOffset(0)]
            private readonly long @long;

            /// <summary>
            /// Double representation of passed value.
            /// </summary>
            [FieldOffset(0)]
            private readonly double @double;

            /// <summary>
            /// Initializes a new instance of the <see cref="DoubleLong"/> struct.
            /// </summary>
            /// <param name="number">
            /// Double value for converting.
            /// </param>
            public DoubleLong(double number)
            {
                @long = 0;
                @double = number;
            }

            /// <summary>
            /// Readonly property for long representaion.
            /// </summary>
            public long LongValue => @long;

            /// <summary>
            /// Readonly property for double representaion.
            /// </summary>
            public double DoubleValue => @double;
        }
    }
}
