using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Polynomial
    {
        private int power;
        private double[] cof;

        public int Power
        {
            get
            {
                return power;
            }
            private set
            {               
                power = value;
            }
        }
        public double[] Cof
        {
            get
            {
                return (double[])cof.Clone();
            }
            private set
            {
                cof = value;
            }
        }


        #region Constructors
        /// <summary>
        /// Initializes a new instance of the zero-degree polynomial that is specified by coefficient
        /// </summary>
        /// <param name="a">Coefficient of zero-degree polynomial</param>
        public Polynomial(double a)
        {
            Cof = new double[1] { a };
            Power = 0;

        }

        /// <summary>
        /// Initializes a new instance of the first-degree polynomial that is specified by coefficients
        /// </summary>
        /// <param name="a">First coefficient of first-degree polynomial</param>
        /// <param name="b">Second coefficient of first-degree polynomial</param>
        public Polynomial(double a, double b)
        {
            Cof = new double[2] { a, b };
            Power = 1;
        }

        /// <summary>
        /// Initializes a new instance of the first-degree polynomial that is specified by coefficients
        /// </summary>
        /// <param name="a">First coefficient of third-degree polynomial</param>
        /// <param name="b">Second coefficient of third-degree polynomial</param>
        /// <param name="c">Third coefficient of third-degree polynomial</param>
        public Polynomial(double a, double b, double c)
        {
            Cof = new double[3] { a, b, c };
            Power = 2;
        }

        /// <summary>
        /// Initializes a new instance of the Polynomial class that is spcified by coefficients
        /// </summary>
        /// <param name="coefficients">Coefficients of polynomial, index is power of polinomal element</param>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException(nameof(coefficients));
            if (coefficients.Length == 0)
            {
                Power = 0;
                Cof = new double[1] { 0 };
            }
            else {
                Power = coefficients.Length - 1;
                for (int i = coefficients.Length - 1; i >= 0; i--)
                    if (coefficients[i] != 0 || i == 0)
                    {
                        Power = i;
                        break;
                    }

                Cof = new double[power + 1];
                Array.Copy(coefficients, this.cof, Power + 1);
            }
        }
        #endregion


        #region Methods
        #region Add/Sub
        /// <summary>
        /// Add two polynomial
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial Add(Polynomial p1, Polynomial p2)
        {   
            if (p1 == null && p2 == null)
                return null;
            if (p1 == null)
                return new Polynomial(p2.Cof);
            if (p2 == null)
                return new Polynomial(p1.Cof);
            double[] newCof = (p1.Power > p2.Power) ? (double[])p1.Cof.Clone() : (double[])p2.Cof.Clone();
            int minPower = (p1.Power < p2.Power) ? p1.Power : p2.Power;
            for (int i = 0; i < minPower + 1; i++)
                newCof[i] = p1.Cof[i] + p2.Cof[i];
            return new Polynomial(newCof);
        }
        /// <summary>
        /// Add two polynomial
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            return Add(p1, p2);
        }
        /// <summary>
        /// Multiply polynomial by minus one
        /// </summary>
        /// <param name="p">Polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial UnaryMinus(Polynomial p)
        {
            if (p == null)
                return null;
            double[] newCof = (double[])p.Cof.Clone();
            for (int i = 0; i < newCof.Length; i++)
                newCof[i] = -p.Cof[i];
            return new Polynomial(newCof);
        }
        /// <summary>
        /// Multiply polynomial by minus one
        /// </summary>
        /// <param name="p">Polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial operator -(Polynomial p)
        {
            return UnaryMinus(p);
        }

        /// <summary>
        /// Sub two polynomial
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial Sub(Polynomial p1, Polynomial p2)
        {
            if (p1 == null && p2 == null)
                return null;
            if (p1 == null)
                return new Polynomial(p2.Cof);
            if (p2 == null)
                return new Polynomial(p1.Cof);
            return p1 + (-p2);
        }
        /// <summary>
        /// Sub two polynomial
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            return Sub(p1, p2);
        }
        #endregion

        #region Multiplication
        /// <summary>
        /// Multiply two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial Multiplication(Polynomial p1, Polynomial p2)
        {
            if (p1  == null || p2 == null)
                return null;

            double[] newCof = new double[p1.Power + 1 + p2.Power + 1];

            for (int i = 0; i <= p1.power; i++)
                for (int j = 0; j <= p2.power; j++)
                    newCof[i + j] += p1.Cof[i] * p2.Cof[j];
                
            return new Polynomial(newCof);

        }
        /// <summary>
        /// Multiply two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            return Multiplication(p1, p2);
        }
        #endregion


        /// <summary>
        /// This method gives string formula representation of polynomial
        /// </summary>
        /// <returns>String representation of polynomial</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Cof.Length; i++)
            {
                if (i == 0)
                    if (Cof[i] < 0)
                        result.Append(Cof[i] + "*" + "x^" + i);
                    else
                        result.Append(Cof[i] + "*" + "x^" + i);
                if (i <= Power && i > 0)
                    if (Cof[i] < 0)
                        result.Append(Cof[i] + "*" + "x^" + i);
                    else
                        result.Append("+" + Cof[i] + "*" + "x^" + i);
            }
            return result.ToString();
        }

        /// <summary>
        /// Determines wether this instance and object witch must be also Polynomial, have same value
        /// </summary>
        /// <param name="p">Polynomial to compare with</param>
        /// <returns></returns>
        public bool Equals(Polynomial p)
        {
            if (ReferenceEquals(p, null)) return false;
            if (ReferenceEquals(this, p)) return true;
            if (Power != p.Power) return false;
            for (int i = 0; i < this.power + 1; i++)
                if (Cof[i] != p.Cof[i])
                    return false;
            return true;
        }

        /// <summary>
        /// Determines wether this instance and object witch must be also Polynomial, have same value
        /// </summary>
        /// <param name="obj">object to compare with</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Polynomial);
        }

        /// <summary>
        /// Compares the two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>Returns true if polynomials are equal</returns>
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if (ReferenceEquals(p1, null) && ReferenceEquals(p2, null)) return true;
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null)) return false;
            return p1.Equals(p2);
        }

        /// <summary>
        /// Compares the two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second Polynomial</param>
        /// <returns>Returns true if polynomials are not equal</returns>
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// This method returns a hash code for the current object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        #endregion
    }
}
