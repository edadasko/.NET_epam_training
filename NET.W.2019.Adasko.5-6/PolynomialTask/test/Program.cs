using System;
using PolynomialTask;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Polynomial(1, 2, 3) + new Polynomial(-1, 2, 3);
            Console.WriteLine(a);
        }
    }
}
