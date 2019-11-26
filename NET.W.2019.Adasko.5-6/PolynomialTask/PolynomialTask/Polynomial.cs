//-----------------------------------------------------------------------
// <copyright file="Polynomial.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace PolynomialTask
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides representation of degree polynomial in one variable of real type.
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// Uses in comparison of two double numbers.
        /// </summary>
        private const double EPSILON = 1E-10;

        /// <summary>
        /// Coefficients of polynimial.
        /// Array begins with the coefficient of the greatest degree.
        /// </summary>
        private readonly double[] coefficients;

        /// <summary>
        /// The greatest degree of polynomial.
        /// </summary>
        private readonly int degree;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coeffs">
        /// Coefficients of polynomial in order of decreasing degree.
        /// </param>
        public Polynomial(params double[] coeffs)
        {
            if (coeffs.Length == 0)
            {
                this.coefficients = coeffs;
                this.degree = -1;
                return;
            }

            // removing first zeros
            int zeroIndex = 0;
            while (zeroIndex < coeffs.Length && Math.Abs(coeffs[zeroIndex]) < EPSILON)
            {
                zeroIndex++;
            }

            coefficients = coeffs[zeroIndex..];
            this.degree = this.coefficients.Length - 1;
        }

        /// <summary>
        /// Overloading + operator for addition two polinomials.
        /// </summary>
        /// <param name="p1">
        /// First polynomial.
        /// </param>
        /// <param name="p2">
        /// Second polynomial.
        /// </param>
        /// <returns>
        /// Result of addition.
        /// </returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
            {
                throw new ArgumentNullException();
            }

            double[] resultCoeffs = p1.degree >= p2.degree ?
                new double[p1.degree + 1] : new double[p2.degree + 1];

            Array.Copy(p1.degree >= p2.degree ? p1.coefficients : p2.coefficients, resultCoeffs, resultCoeffs.Length);

            int indexP1 = p1.degree, indexP2 = p2.degree;
            int maxIndex = Math.Max(indexP1, indexP2);

            while (indexP1 >= 0 && indexP2 >= 0)
            {
                resultCoeffs[maxIndex] = p1.coefficients[indexP1] + p2.coefficients[indexP2];
                indexP1--;
                indexP2--;
                maxIndex--;
            }

            return new Polynomial(resultCoeffs);
        }

        /// <summary>
        /// Overloading + operator for addition polynomial with double number.
        /// </summary>
        /// <param name="p">
        /// Polynomial for addition.
        /// </param>
        /// <param name="num">
        /// Double number for addition.
        /// </param>
        /// <returns>
        /// Result of addition.
        /// </returns>
        public static Polynomial operator +(Polynomial p, double num) => p + new Polynomial(num);

        /// <summary>
        /// Overloading + operator for addition number with polynomial.
        /// </summary>
        /// <param name="num">
        /// Double number for addition.
        /// </param>
        /// <param name="p">
        /// Polynomial for addition.
        /// </param>
        /// <returns>
        /// Result of addition.
        /// </returns>
        public static Polynomial operator +(double num, Polynomial p) => p + num;

        /// <summary>
        /// Overloading 'unary -' operator for negation a polynomial.
        /// </summary>
        /// <param name="p">
        /// Polynomial for negation.
        /// </param>
        /// <returns>
        /// Negative polynomial.
        /// </returns>
        public static Polynomial operator -(Polynomial p)
        {
            if (p == null)
            {
                throw new ArgumentNullException();
            }

            double[] resultCoeffs = new double[p.degree + 1];

            for (int i = 0; i < p.degree + 1; i++)
            {
                resultCoeffs[i] = -p.coefficients[i];
            }

            return new Polynomial(resultCoeffs);
        }

        /// <summary>
        /// Overloading - operator for subtraction two polynomials.
        /// </summary>
        /// <param name="p1">
        /// First polynomial.
        /// </param>
        /// <param name="p2">
        /// Second polynomial.
        /// </param>
        /// <returns>
        /// Result of subtraction.
        /// </returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2) => p1 + -p2;

        /// <summary>
        /// Overloading - operator for subtraction polynomial and number.
        /// </summary>
        /// <param name="p">
        /// Polynomial for subtraction.
        /// </param>
        /// <param name="num">
        /// Number for subtraction.
        /// </param>
        /// <returns>
        /// Result of subtraction.
        /// </returns>
        public static Polynomial operator -(Polynomial p, double num) => p + -num;

        /// <summary>
        /// Overloading - operator for subtraction number and polynomial.
        /// </summary>
        /// <param name="num">
        /// Number for subtraction.
        /// </param>
        /// <param name="p">
        /// Polynomial for subtraction.
        /// </param>
        /// <returns>
        /// Result of subtraction.
        /// </returns>
        public static Polynomial operator -(double num, Polynomial p) => num + -p;

        /// <summary>
        /// Overloading * operator for multiplication two polynomials.
        /// </summary>
        /// <param name="p1">
        /// First polynomial.
        /// </param>
        /// <param name="p2">
        /// Second polynomial.
        /// </param>
        /// <returns>
        /// Result of multiplication.
        /// </returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
            {
                throw new ArgumentNullException();
            }

            double[] resultCoeffs = new double[p1.degree + p2.degree + 1];
            for (int indexP1 = 0; indexP1 < p1.degree + 1; indexP1++)
            {
                for (int indexP2 = 0; indexP2 < p2.degree + 1; indexP2++)
                {
                    resultCoeffs[indexP1 + indexP2] += p1.coefficients[indexP1] * p2.coefficients[indexP2];
                }
            }

            return new Polynomial(resultCoeffs);
        }

        /// <summary>
        /// Overloading * operator for multiplication polynomial and number.
        /// </summary>
        /// <param name="p">
        /// Polynomial for multiplication.
        /// </param>
        /// <param name="num">
        /// Number for multiplication.
        /// </param>
        /// <returns>
        /// Result of multiplication.
        /// </returns>
        public static Polynomial operator *(Polynomial p, double num) => p * new Polynomial(num);

        /// <summary>
        /// Overloading * operator for multiplication number and polynomial.
        /// </summary>
        /// <param name="num">
        /// Number for multiplication.
        /// </param>
        /// <param name="p">
        /// Polynomial for multiplication.
        /// </param>
        /// <returns>
        /// Result of multiplication.
        /// </returns>
        public static Polynomial operator *(double num, Polynomial p) => p * num;

        /// <summary>
        /// Overloading / operator for division polynomial and number.
        /// </summary>
        /// <param name="p">
        /// Polynomial for division.
        /// </param>
        /// <param name="num">
        /// Number for division.
        /// </param>
        /// <returns>
        /// Result of division.
        /// </returns>
        public static Polynomial operator /(Polynomial p, double num)
        {
            if (p == null)
            {
                throw new ArgumentNullException();
            }

            if (Math.Abs(num) < EPSILON)
            {
                throw new DivideByZeroException();
            }

            return p * (1 / num);
        }

        /// <summary>
        /// Overloading == operator for comparison two polynomials.
        /// </summary>
        /// <param name="p1">
        /// First polynomial.
        /// </param>
        /// <param name="p2">
        /// Second polynomial.
        /// </param>
        /// <returns>
        /// Boolean result of comparison.
        /// </returns>
        public static bool operator ==(Polynomial p1, Polynomial p2) => p1.Equals(p2);

        /// <summary>
        /// Overloading != operator for comparison two polynomials.
        /// </summary>
        /// <param name="p1">
        /// First polynomial.
        /// </param>
        /// <param name="p2">
        /// Second polynomial.
        /// </param>
        /// <returns>
        /// Boolean result of comparison.
        /// </returns>
        public static bool operator !=(Polynomial p1, Polynomial p2) => !p1.Equals(p2);

        /// <summary>
        /// Overloading == operator for comparison polynomial with number.
        /// </summary>
        /// <param name="p">
        /// Polynomial for comparison.
        /// </param>
        /// <param name="num">
        /// Number for comparison.
        /// </param>
        /// <returns>
        /// Boolean result of comparison.
        /// </returns>
        public static bool operator ==(Polynomial p, double num) => p.Equals(new Polynomial(num));

        /// <summary>
        /// Overloading != operator for comparison polynomial with number.
        /// </summary>
        /// <param name="p">
        /// Polynomial for comparison.
        /// </param>
        /// <param name="num">
        /// Number for comparison.
        /// </param>
        /// <returns>
        /// Boolean result of comparison.
        /// </returns>
        public static bool operator !=(Polynomial p, double num) => !p.Equals(new Polynomial(num));

        /// <summary>
        /// Overloading == operator for comparison number with polynomial.
        /// </summary>
        /// <param name="num">
        /// Number for comparison.
        /// </param>
        /// <param name="p">
        /// Polynomial for comparison.
        /// </param>
        /// <returns>
        /// Boolean result of comparison.
        /// </returns>
        public static bool operator ==(double num, Polynomial p) => p.Equals(new Polynomial(num));

        /// <summary>
        /// Overloading != operator for comparison number with polynomial.
        /// </summary>
        /// <param name="num">
        /// Number for comparison.
        /// </param>
        /// <param name="p">
        /// Polynomial for comparison.
        /// </param>
        /// <returns>
        /// Boolean result of comparison.
        /// </returns>
        public static bool operator !=(double num, Polynomial p) => !p.Equals(new Polynomial(num));

        /// <summary>
        /// Converts polynomial to string.
        /// Format: 7x^4 + 5x^3 + 6x + 9
        /// </summary>
        /// <returns>
        /// String representation of polynomial.
        /// </returns>
        public override string ToString()
        {
            var listOfDegrees = new List<string>();
            var currentDegree = this.degree;

            foreach (var coeff in this.coefficients)
            {
                if (Math.Abs(coeff) < EPSILON)
                {
                    currentDegree--;
                    continue;
                }

                // if coeff == 1 or -1 => strCoeff = "" or "-"
                string strCoeff = Math.Abs(coeff - 1) < EPSILON ? string.Empty :
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

        /// <summary>
        /// Compare polynomial with object.
        /// </summary>
        /// <param name="obj">
        /// Object to compare.
        /// </param>
        /// <returns>
        /// Bool result of comparison.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Polynomial other))
            {
                return false;
            }

            if (this.degree != other.degree)
            {
                return false;
            }

            for (int i = 0; i < this.degree + 1; i++)
            {
                if (Math.Abs(other.coefficients[i] - this.coefficients[i]) > EPSILON)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Computes hash code for polynomial.
        /// </summary>
        /// <returns>
        /// Hash code of polynomial.
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 0;

            for (int i = 0; i < this.degree + 1; i++)
            {
                hash ^= this.coefficients[i].GetHashCode();
            }

            return hash;
        }
    }
}