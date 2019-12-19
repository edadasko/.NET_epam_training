//-----------------------------------------------------------------------
// <copyright file="Matrix.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace MatricesTask
{
    using System;

    /// <summary>
    /// Generic class which represents a matrix.
    /// </summary>
    /// <typeparam name="T">Type of values of a matrix.</typeparam>
    public class Matrix<T> : IEquatable<Matrix<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="elements">Elements of a matrix.</param>
        public Matrix(T[,] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException();
            }

            this.NumRows = elements.GetLength(0);
            this.NumColumns = elements.GetLength(1);
            this.Elements = new T[this.NumRows, this.NumColumns];
            Array.Copy(elements, this.Elements, elements.Length);
        }

        /// <summary>
        /// Event which raised when element of a matrix changed. 
        /// </summary>
        public event EventHandler<MatrixChangedEventArgs<T>> ElementChangedEvent;

        /// <summary>
        /// Gets elements of matrix.
        /// </summary>
        public T[,] Elements { get; private set; }

        /// <summary>
        /// Gets number of rows.
        /// </summary>
        protected int NumRows { get; private set; }

        /// <summary>
        /// Gets number of columns.
        /// </summary>
        protected int NumColumns { get; private set; }

        /// <summary>
        /// Indexator for matrix.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        /// <returns>Element by indexes.</returns>
        public T this[int i, int j]
        {
            get
            {
                this.CheckIndexes(i, j);
                return this.Elements[i, j];
            }

            set
            {
                this.CheckIndexes(i, j);
                this.OnElementChanged(
                    this,
                    new MatrixChangedEventArgs<T>(i, j, this.Elements[i, j], value));
                this.Elements[i, j] = value;
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }

            if (obj is Matrix<T> m)
            {
                this.Equals(m);
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Elements.GetHashCode();
        }

        /// <inheritdoc/>
        public bool Equals(Matrix<T> other)
        {
            if (this.NumRows != other.NumRows ||
                this.NumColumns != other.NumColumns)
            {
                return false;
            }

            for (int i = 0; i < this.NumRows; i++)
            {
                for (int j = 0; j < this.NumColumns; j++)
                {
                    if (!object.Equals(this.Elements[i, j], other.Elements[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Invokes event.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Arguments for event.</param>
        protected void OnElementChanged(object sender, MatrixChangedEventArgs<T> e)
            => this.ElementChangedEvent?.Invoke(sender, e);

        /// <summary>
        /// Checks if indexes are valid.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        private void CheckIndexes(int i, int j)
        {
            if (i < 0 || j < 0 || i > this.NumRows || j > this.NumColumns)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
