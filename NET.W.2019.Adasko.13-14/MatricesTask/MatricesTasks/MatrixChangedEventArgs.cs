//-----------------------------------------------------------------------
// <copyright file="MatrixChangedEventArgs.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace MatricesTask
{
    using System;

    /// <summary>
    /// Provides arguments for element changing event.
    /// </summary>
    /// <typeparam name="T">Type of values in matrix.</typeparam>
    public class MatrixChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixChangedEventArgs{T}"/> class.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        /// <param name="old">Old value.</param>
        /// <param name="new">New value.</param>
        public MatrixChangedEventArgs(int i, int j, T old, T @new)
        {
            this.RowIndex = i;
            this.ColumnIndex = j;
            this.Old = old;
            this.New = @new;
        }

        /// <summary>
        /// Gets or sets a row index.
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// Gets or sets a column index.
        /// </summary>
        public int ColumnIndex { get; set; }

        /// <summary>
        /// Gets or sets an old value.
        /// </summary>
        public T Old { get; set; }

        /// <summary>
        /// Gets or sets a new value.
        /// </summary>
        public T New { get; set; }
    }
}
