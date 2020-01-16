//-----------------------------------------------------------------------
// <copyright file="MatrixAddition.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace MatricesTask
{
    using System;

    /// <summary>
    /// Provides extension method for matrix addition.
    /// </summary>
    public static class MatrixAddition
    {
        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <typeparam name="T">Type of matrices values.</typeparam>
        /// <param name="matrix1">First matrix.</param>
        /// <param name="matrix2">Second matrix.</param>
        /// <returns>Result of addition.</returns>
        public static Matrix<T> Add<T>(this Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException();
            }

            int rowsNum = matrix1.Elements.GetLength(0);
            int columnsNum = matrix1.Elements.GetLength(1);
            if (matrix2.Elements.GetLength(0) != rowsNum &&
                matrix2.Elements.GetLength(1) != columnsNum)
            {
                throw new InvalidOperationException();
            }

            T[,] matrixResult = new T[rowsNum, columnsNum];
            for (int i = 0; i < rowsNum; i++)
            {
                for (int j = 0; j < columnsNum; j++)
                {
                    dynamic a = matrix1[i, j];
                    dynamic b = matrix2[i, j];

                    try
                    {
                        matrixResult[i, j] = a + b;
                    }
                    catch (Exception)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            return new Matrix<T>(matrixResult);
        }
    }
}
