//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace ConsoleTreeTest
{
    using System;
    using BST_Task;

    /// <summary>
    /// Tests binary search tree.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Tests operations with BST of different types.
        /// </summary>
        public static void Main()
        {
            BinarySearchTree<int> intBST = new BinarySearchTree<int>();

            intBST.Insert(1);
            intBST.Insert(5);
            intBST.Insert(-1);
            intBST.Insert(-2);
            intBST.Insert(2);
            intBST.Insert(3);

            intBST.Remove(1);

            foreach (var n in intBST)
            {
                Console.WriteLine(n);
            }

            BinarySearchTree<Point> pointBST = new BinarySearchTree<Point>(new PointComparer());

            pointBST.Insert(new Point(1, 1));
            pointBST.Insert(new Point(0, 0));
            pointBST.Insert(new Point(5, 3));
            pointBST.Insert(new Point(10, 10));
            pointBST.Insert(new Point(-100, -10));

            foreach (var p in pointBST)
            {
                Console.WriteLine(p);
            }
        }
    }
}
