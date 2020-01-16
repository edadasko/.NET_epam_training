//-----------------------------------------------------------------------
// <copyright file="SquareMatrix.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace MatricesTask
{
    using System;

    /// <summary>
    /// Generic class which represents a square matrix.
    /// </summary>
    /// <typeparam name="T">Type of values of a matrix.</typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="elements">Elements of a matrix.</param>
        public SquareMatrix(T[,] elements) : base(elements)
        {
            this.CheckArray(elements);
        }

        /// <summary>
        /// Checks if array is correct.
        /// </summary>
        /// <param name="array">Array to check.</param>
        protected void CheckArray(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException();
            }                
        }
    }
}
