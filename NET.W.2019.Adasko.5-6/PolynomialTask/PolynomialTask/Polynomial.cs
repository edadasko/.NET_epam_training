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
            if(coeffs.Length == 0)
            {
                coefficients = coeffs;
                degree = -1;
                return;
            }

            //removing first zeros
            int zeroIndex = 0;
            while (zeroIndex < coeffs.Length && Math.Abs(coeffs[zeroIndex]) < EPSILON)
            {
                zeroIndex++;
            }

            coefficients = coeffs[zeroIndex..];
            degree = coefficients.Length - 1;
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
            if (obj == null)
                return false;

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

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            double[] resultCoeffs;

            if (p1.degree >= p2.degree)
                resultCoeffs = p1.coefficients;
            else
                resultCoeffs = p2.coefficients;


            int p1Index = p1.degree, p2Index = p2.degree;
            int maxIndex = Math.Max(p1Index, p2Index);

            while(p1Index >= 0 && p2Index >= 0)
            {
                resultCoeffs[maxIndex] = p1.coefficients[p1Index] + p2.coefficients[p2Index];
                p1Index--;
                p2Index--;
                maxIndex--;
            }

            return new Polynomial(resultCoeffs);
        }

        public static Polynomial operator +(Polynomial p, double num) => p + new Polynomial(num);
        public static Polynomial operator +(double num, Polynomial p) => p + num;

        public static Polynomial operator -(Polynomial p)
        {
            Polynomial result = new Polynomial(p.coefficients);
            for (int i = 0; i < result.degree + 1; i++)
            {
                result.coefficients[i] = -result.coefficients[i];
            }

            return result;
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2) => p1 + -p2;
        public static Polynomial operator -(Polynomial p, double num) => p + -num;
        public static Polynomial operator -(double num, Polynomial p) => num + -p;

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            double[] resultCoeffs = new double[p1.degree + p2.degree + 1];
            for (int p1Index = 0; p1Index < p1.degree + 1; p1Index++)
            {
                for (int p2Index = 0; p2Index < p2.degree + 1; p2Index++)
                {
                    resultCoeffs[p1Index + p2Index] += p1.coefficients[p1Index] * p2.coefficients[p2Index];
                }
            }

            return new Polynomial(resultCoeffs);
        }

        public static Polynomial operator *(Polynomial p, double num) => p * new Polynomial(num);
        public static Polynomial operator *(double num, Polynomial p) => p * num;

        public static bool operator ==(Polynomial p1, Polynomial p2) => p1.Equals(p2);
        public static bool operator !=(Polynomial p1, Polynomial p2) => !p1.Equals(p2);
        public static bool operator ==(Polynomial p, double num) => p.Equals(new Polynomial(num));
        public static bool operator !=(Polynomial p, double num) => !p.Equals(new Polynomial(num));
        public static bool operator ==(double num, Polynomial p) => p.Equals(new Polynomial(num));
        public static bool operator !=(double num, Polynomial p) => !p.Equals(new Polynomial(num));
    }
}
