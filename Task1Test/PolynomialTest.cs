using System;
using System.Configuration;
using Task1;
using NUnit.Framework;

namespace Task1Test
{
    [TestFixture]
    public class PolynomialTest
    {
       
        [Test]
        public void Equals_ObjectAndThis()
        {
            Polynomial a = new Polynomial( 2, 1);
            bool expeexpectation = true, reality = a.Equals(a);
            Assert.AreEqual(expeexpectation, reality);
        }

        [Test]
        public void Equals_ObjectAndNull()
        {
            Polynomial a = new Polynomial(3, 2, 1);
            bool expeexpectation = false, reality = a.Equals(null);
            Assert.AreEqual(expeexpectation, reality);
        }

        [Test]
        public void Equals_SameObjectAndObject()
        {
            Polynomial p1 = new Polynomial(3, 2, 1), p2 = new Polynomial(3, 2, 1);
            bool expeexpectation = true, reality = p1.Equals(p2);
            Assert.AreEqual(expeexpectation, reality);
        }

        [Test]
        public void Equals_DifferentObjectAndObject()
        {
            Polynomial p1 = new Polynomial(3, 2, 1), p2 = new Polynomial(1, 2, 3);
            bool expeexpectation = false, reality = p1.Equals(p2);
            Assert.AreEqual(expeexpectation, reality);
        }


        static object[] operationPlusTestData =
        {
            new object[] { new Polynomial(3, 2, 1), new Polynomial(1, 2, 3), new Polynomial(4, 4, 4) },
            new object[] { new Polynomial(-1, -2, -3, -4, -5, -6), new Polynomial(2, 3, 4, 5, 6), new Polynomial(1, 1, 1, 1, 1, -6) },
            new object[] { new Polynomial(2.6, -13, 0.25, 17, 30), null, new Polynomial(2.6, -13, 0.25, 17, 30) }
        };

        [Test, TestCaseSource("operationPlusTestData")]
        public void OperatorPlus_positiveValues(Polynomial p1, Polynomial p2, Polynomial expeexpectation)
        {
            Polynomial reality = p1 + p2;
            Assert.IsTrue(reality.Equals(expeexpectation));

        }

        static object[] operationUnaryMinusTestData =
        {
            new object[] { new Polynomial(1, 2, 3, 4, 5, 6), new Polynomial(-1, -2, -3, -4, -5, -6) },
            new object[] { new Polynomial(-1, -2, -3, -4, -5, -6), new Polynomial(1, 2, 3, 4, 5, 6) },
        };

        [Test, TestCaseSource("operationUnaryMinusTestData")]
        public void OperatorUnaryMinus_positiveValues(Polynomial p, Polynomial expeexpectation)
        {
            Polynomial reality = - p;
            Assert.IsTrue(reality.Equals(expeexpectation));

        }

        static object[] operationSubTestData =
        {
            new object[] { new Polynomial(1, 2, 3, 4, 5, 6), new Polynomial(2, 3, 4, 5, 6), new Polynomial(-1, -1, -1, -1, -1, 6) },
            new object[] { new Polynomial(-1, -2, -3, -4, -5, -6), new Polynomial(-2, -3, -4, -5, -6), new Polynomial(1, 1, 1, 1, 1, -6) },
            new object[] { new Polynomial(2.6, -13, 0.25, 17, 30), null, new Polynomial(2.6, -13, 0.25, 17, 30) }
        };

        [Test, TestCaseSource("operationSubTestData")]
        public void OperatorSub_positiveValues(Polynomial p1, Polynomial p2, Polynomial expeexpectation)
        {
            Polynomial reality = p1 - p2;
            Assert.IsTrue(reality.Equals(expeexpectation));

        }

        static object[] operationMultiplyTestData =
        {
            new object[] { new Polynomial(1, 2, 3), new Polynomial(2, 3), new Polynomial(2, 7, 12, 9) },
            new object[] { new Polynomial(-1, -2, -3), new Polynomial(2, 3), new Polynomial(-2, -7, -12, -9) },
            new object[] { new Polynomial(1, 2, 3), new Polynomial(), new Polynomial(0) },
        };

        [Test, TestCaseSource("operationMultiplyTestData")]
        public void OperatorMultiply_positiveValues(Polynomial p1, Polynomial p2, Polynomial expeexpectation)
        {
            Polynomial reality = p1 * p2;
            Assert.IsTrue(reality.Equals(expeexpectation));

        }

    }
}
