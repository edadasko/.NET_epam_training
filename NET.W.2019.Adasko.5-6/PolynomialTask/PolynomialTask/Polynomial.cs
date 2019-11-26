using System;
using System.Collections.Generic;

namespace PolynomialTask
{
    public sealed class Polynomial
    {
        private readonly double[] coefficients;
        private readonly int degree;
        private const double EPSILON = 0.0000000001;

        public Polynomial(params double[] coeffs)
        {
            if (coeffs.Length < 1)
                throw new ArgumentException();

            coefficients = coeffs;
            degree = coeffs.Length - 1;
        }

        public override string ToString()
        {
            var listOfDegrees = new List<string>();
            var currentDegree = degree;

            foreach (var coeff in coefficients)
            {
                if (Math.Abs(coeff) < EPSILON)
                {
                    currentDegree--;
                    continue;
                }

                // if coeff == 1 or -1 => strCoeff = "" or "-"
                string strCoeff = Math.Abs(coeff - 1) < EPSILON ? "" :
                    Math.Abs(coeff + 1) < EPSILON ? "-" : coeff.ToString();

                if (currentDegree > 1)
                {
                    listOfDegrees.Add(strCoeff + "x^" + currentDegree);
                }
                else if (currentDegree == 1)
                {
                    listOfDegrees.Add(strCoeff + "x");
                }
                else
                {
                    listOfDegrees.Add(strCoeff);
                }

                currentDegree--;
            }

            return string.Join(" + ", listOfDegrees);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial other))
            {
                return false;
            }

            if (this.degree != other.degree)
            {
                return false;
            }

            for (int i = 0; i < degree + 1; i ++)
            {
                if (Math.Abs(other.coefficients[i] - this.coefficients[i]) > EPSILON)
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < degree + 1; i++)
            {
                hash ^= coefficients[i].GetHashCode();
            }
            return hash;
        }
    }
}
