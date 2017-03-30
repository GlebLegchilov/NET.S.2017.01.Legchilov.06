using Task2;
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
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 0, 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 }, new int[] {11,22}}, new CompareBySumUp() },
            new object[] { new int[][] { new int[] {15, 17,0,68}, new int[] { 17, 2, 9 }, new int[] { 20, 21 } }, new int[][] { new int[] { 17, 2, 9 }, new int[] { 20, 21 }, new int[] { 15, 17, 0, 68 } }, new CompareBySumUp() }
        };

        static object[] SortByElementSumDown =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 11, 22 }, new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 } }, new CompareBySumDown() },
            new object[] { new int[][] { new int[] { 17, 2, 9 }, new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 } }, new int[][] { new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 }, new int[] { 17, 2, 9 } }, new CompareBySumDown() }
        };

        [Test, TestCaseSource("SortByElementSumUp")]
        public void SortByElementSumUp_PositivTest(int[][] reality, int[][] expeexpectation, IComparer comparer)
        {
            Sort(reality, comparer);
            Assert.AreEqual(expeexpectation, reality);
        }

        [Test, TestCaseSource("SortByElementSumDown")]
        public void SortByElementSumDown_PositivTest(int[][] reality, int[][] expeexpectation, IComparer comparer)
        {
            Sort(reality, comparer);
            Assert.AreEqual(expeexpectation, reality);
        }
        #endregion

        #region SortByMaxElementTest
        static object[] SortByMaxElementUp =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 0, 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 }, new int[] {11,22}}, new CompareByMaxUp() },
            new object[] { new int[][] { new int[] {15, 17,0,68}, new int[] { 17, 2, 9 }, new int[] { 20, 21 } }, new int[][] { new int[] { 17, 2, 9 }, new int[] { 20, 21 }, new int[] { 15, 17, 0, 68 } }, new CompareByMaxUp() }
        };

        static object[] SortByMaxElementDown =
        {
            new object[] { new int[][] { new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 }, new int[] { 11, 22 } }, new int[][] { new int[] { 11, 22 }, new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6 } }, new CompareByMaxDown() },
            new object[] { new int[][] { new int[] { 17, 2, 9 }, new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 } }, new int[][] { new int[] { 15, 17, 0, 68 }, new int[] { 20, 21 }, new int[] { 17, 2, 9 } }, new CompareByMaxDown() }
        };

        [Test, TestCaseSource("SortByMaxElementUp")]
        public void SortByMaxElementUp_PositivTest(int[][] reality, int[][] expeexpectation, IComparer comparer)
        {
            Sort(reality, comparer);
            Assert.AreEqual(expeexpectation, reality);
        }

        [Test, TestCaseSource("SortByMaxElementDown")]
        public void SortByMaxElementDown_PositivTest(int[][] reality, int[][] expeexpectation, IComparer comparer)
        {
            Sort(reality, comparer);
            Assert.AreEqual(expeexpectation, reality);
        }
        #endregion


    }
}
