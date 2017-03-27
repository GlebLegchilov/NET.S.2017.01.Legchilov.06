using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Task2.BubbleMatrixSort;
using NUnit.Framework;

namespace Task2Test
{
    [TestFixture]
    public class BubbleMatrixSortTest
    {
        #region SortByElementSumTest
        static object[] SortByElementSumUp =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 0, 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 }, new int[] {11,22}} },
            new object[] { new int[][] { new int[] {15, 17,0,68}, new int[] { 17, 2, 9 }, new int[] { 20, 21 } }, new int[][] { new int[] { 17, 2, 9 }, new int[] { 20, 21 }, new int[] { 15, 17, 0, 68 } } }
        };

        static object[] SortByElementSumDown =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 11, 22 }, new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 } } },
            new object[] { new int[][] { new int[] { 17, 2, 9 }, new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 } }, new int[][] { new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 }, new int[] { 17, 2, 9 } } }
        };

        [Test, TestCaseSource("SortByElementSumUp")]
        public void SortByElementSumUp_PositivTest(int[][] reality, int[][] expeexpectation)
        {
            SortByElementSumUp(reality);
            Assert.AreEqual(expeexpectation, reality);
        }

        [Test, TestCaseSource("SortByElementSumDown")]
        public void SortByElementSumDown_PositivTest(int[][] reality, int[][] expeexpectation)
        {
            SortByElementSumDown(reality);
            Assert.AreEqual(expeexpectation, reality);
        }
        #endregion

        #region SortByMaxElementTest
        static object[] SortByMaxElementUp =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 0, 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 }, new int[] {11,22}} },
            new object[] { new int[][] { new int[] {15, 17,0,68}, new int[] { 17, 2, 9 }, new int[] { 20, 21 } }, new int[][] { new int[] { 17, 2, 9 }, new int[] { 20, 21 }, new int[] { 15, 17, 0, 68 } } }
        };

        static object[] SortByMaxElementDown =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 11, 22 }, new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 } } },
            new object[] { new int[][] { new int[] { 17, 2, 9 }, new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 } }, new int[][] { new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 }, new int[] { 17, 2, 9 } } }
        };

        [Test, TestCaseSource("SortByMaxElementUp")]
        public void SortByMaxElementUp_PositivTest(int[][] reality, int[][] expeexpectation)
        {
            SortByMaxElementUp(reality);
            Assert.AreEqual(expeexpectation, reality);
        }

        [Test, TestCaseSource("SortByMaxElementDown")]
        public void SortByMaxElementDown_PositivTest(int[][] reality, int[][] expeexpectation)
        {
            SortByMaxElementDown(reality);
            Assert.AreEqual(expeexpectation, reality);
        }
        #endregion

        #region SortByMinElementTest
        static object[] SortByMinElementUp =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] {new int[] { 11, 22 }, new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 } } },
            new object[] { new int[][] { new int[] {15, 17,0,68}, new int[] { 17, 2, 9 }, new int[] { 20, 21 } }, new int[][] { new int[] { 20, 21 }, new int[] { 17, 2, 9 }, new int[] { 15, 17, 0, 68 } } }
        };

        static object[] SortByMinElementDown =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 0, 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 }, new int[] {11,22}} },
            new object[] { new int[][] { new int[] { 17, 2, 9 }, new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 } }, new int[][] { new int[] { 15, 17, 0, 68 }, new int[] { 17, 2, 9 }, new int[] { 20, 21 } } }
        };

        [Test, TestCaseSource("SortByMinElementUp")]
        public void SortByMinElementUp_PositivTest(int[][] reality, int[][] expeexpectation)
        {
            SortByMinElementUp(reality);
            Assert.AreEqual(expeexpectation, reality);
        }

        [Test, TestCaseSource("SortByMinElementDown")]
        public void SortByMinElementDown_PositivTest(int[][] reality, int[][] expeexpectation)
        {
            SortByMinElementDown(reality);
            Assert.AreEqual(expeexpectation, reality);
        }
        #endregion
    }
}
