using System;
using System.Text;
using System.Configuration;

namespace Task1
{
    public sealed class Polynomial
    {
        public static double epsilon = 0.00000001;

        private int power;
        private double[] cof;

        public int Power
        {
            get
            {
                if (cof.Length == 1)
                    return 0;
                int i;
                for (i = cof.Length - 1; i >= 0; i-- )
                {
                    if (Math.Abs(cof[i]) > epsilon)
                        break;
                }
                return i;
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
                for (int i = value.Length - 1; i >= 0; i--)
                    if (value[i] != 0 || i == 0)
                    {
                        power = i;
                        break;
                    }

                cof = value;
            }
        }

        public double this[int number]
        {
            get
            {
                if (power > cof.Length)
                    throw new IndexOutOfRangeException();
                return cof[power];
            }
        }


        #region Constructors

        static Polynomial()
        {
            try
            {
                epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"]);
            }
            catch
            {
            }
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
                power = 0;
                Cof = new double[1] { 0 };
            }
            else {
                power = coefficients.Length - 1;
                for (int i = coefficients.Length - 1; i >= 0; i--)
                    if (coefficients[i] != 0 || i == 0)
                    {
                        power = i;
                        break;
                    }

                Cof = new double[power + 1];
                Array.Copy(coefficients, this.cof, power + 1);
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
        public static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {   
            if (lhs == null && rhs == null)
                return null;
            if (lhs == null)
                return new Polynomial(rhs.Cof);
            if (rhs == null)
                return new Polynomial(lhs.Cof);
            double[] newCof = (lhs.Power > rhs.Power) ? (double[])lhs.Cof.Clone() : (double[])rhs.Cof.Clone();
            int minPower = (lhs.Power < rhs.Power) ? lhs.Power : rhs.Power;
            for (int i = 0; i < minPower + 1; i++)
                newCof[i] = lhs.Cof[i] + rhs.Cof[i];
            return new Polynomial(newCof);
        }
        /// <summary>
        /// Add two polynomial
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            return Add(lhs, rhs);
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
        public static Polynomial Sub(Polynomial lhs, Polynomial rhs)
        {
            if (lhs == null && rhs == null)
                return null;
            if (lhs == null)
                return new Polynomial(rhs.Cof);
            if (rhs == null)
                return new Polynomial(lhs.Cof);
            return lhs + (-rhs);
        }
        /// <summary>
        /// Sub two polynomial
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            return Sub(lhs, rhs);
        }
        #endregion

        #region Multiplication
        /// <summary>
        /// Multiply two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial Multiplication(Polynomial lhs, Polynomial rhs)
        {
            if (lhs == null || rhs == null)
                return null;

            double[] newCof = new double[lhs.Power + 1 + rhs.Power + 1];

            for (int i = 0; i <= lhs.power; i++)
                for (int j = 0; j <= rhs.power; j++)
                    newCof[i + j] += lhs.Cof[i] * rhs.Cof[j];
                
            return new Polynomial(newCof);

        }
        /// <summary>
        /// Multiply two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>New polynomial</returns>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            return Multiplication(lhs, rhs);
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
            if (power != p.power) return false;
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
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as Polynomial);
        }

        /// <summary>
        /// Compares the two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second polynomial</param>
        /// <returns>Returns true if polynomials are equal</returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null)) return true;
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) return false;
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares the two polynomials
        /// </summary>
        /// <param name="p1">First polynomial</param>
        /// <param name="p2">Second Polynomial</param>
        /// <returns>Returns true if polynomials are not equal</returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !(lhs == rhs);
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
