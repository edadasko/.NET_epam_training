//-----------------------------------------------------------------------
// <copyright file="Point.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace ConsoleTreeTest
{
    /// <summary>
    /// Represents a point on a coordinate plane.
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// X value.
        /// </summary>
        public int X;

        /// <summary>
        /// Y value.
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> structure.
        /// </summary>
        /// <param name="x">X value.</param>
        /// <param name="y">Y value.</param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "(" + this.X + ", " + this.Y + ")";
        }
    }
}
