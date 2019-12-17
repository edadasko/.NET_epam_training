//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace ConsoleTest
{
    using System;
    using QueueTask;

    /// <summary>
    /// Tests working with Queue class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Tests queue.
        /// </summary>
        public static void Main()
        {
            Queue<int> intQ = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                intQ.Push(i);
            }

            foreach (var a in intQ)
            {
                Console.WriteLine(a);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(intQ.Pop());
            }

            Queue<string> stringQ = new Queue<string>();
            stringQ.Push("12345");
            stringQ.Push("98765");
            stringQ.Push("123");
            stringQ.Pop();

            foreach (var a in stringQ)
            {
                Console.WriteLine(a);
            }
        }
    }
}
