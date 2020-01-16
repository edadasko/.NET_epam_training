//-----------------------------------------------------------------------
// <copyright file="PointComparer.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace ConsoleTreeTest
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Comparer for points.
    /// </summary>
    public class PointComparer : IComparer<Point>
    {
        /// <inheritdoc/>
        public int Compare(Point a, Point b)
            => this.VectorLength(a).CompareTo(this.VectorLength(b));

        /// <summary>
        /// Calculates a length of radius vector.
        /// </summary>
        /// <param name="p">Point to calculate.</param>
        /// <returns>A length of radius vector.</returns>
        private double VectorLength(Point p) => Math.Sqrt((p.X * p.X) + (p.Y * p.Y));
    }
}
