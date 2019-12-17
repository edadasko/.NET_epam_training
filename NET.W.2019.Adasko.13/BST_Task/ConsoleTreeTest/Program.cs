using System;
using System.Collections.Generic;
using BST_Task;
namespace ConsoleTreeTest
{
    class Program
    {
        public struct Point
        {
            public int a;
            public int b;

            public Point(int a, int b)
            {
                this.a = a;
                this.b = b;
            }

            public override string ToString()
            {
                return "(" + a + ", " + b + ")";
            }
        }

        public class PointComparer : IComparer<Point>
        {
            public int Compare(Point x, Point y)
                => VectorLength(x).CompareTo(VectorLength(y));

            private double VectorLength(Point p) => Math.Sqrt(p.a * p.a + p.b * p.b);
        }

        static void Main(string[] args)
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
