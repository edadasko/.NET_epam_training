//-----------------------------------------------------------------------
// <copyright file="SymmetricMatrix.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace MatricesTask
{ 
    using System;

    /// <summary>
    /// Generic class which represents a symmetric matrix.
    /// </summary>
    /// <typeparam name="T">Type of values of a matrix.</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="elements">Elements of a matrix.</param>
        public SymmetricMatrix(T[,] elements) : base(elements)
        {
            this.CheckArray(elements);
        }

        /// <summary>
        /// Checks if array is correct.
        /// </summary>
        /// <param name="array">Array to check.</param>
        protected new void CheckArray(T[,] array)
        {
            base.CheckArray(array);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = i; j < array.GetLength(1); j++)
                {
                    if (!object.Equals(array[i, j], array[j, i]))
                    {
                        throw new ArgumentException();
                    }
                }
            }
        }
    }
}
