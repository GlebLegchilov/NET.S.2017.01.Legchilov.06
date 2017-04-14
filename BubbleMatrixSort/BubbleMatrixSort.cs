using System;
using System.Linq;

namespace Task2
{
    public interface IComparer
    {
        int Compare(int[] arr1, int[] arr2);
 
    }

    internal class CompareByDelegate : IComparer
    {
        private Comparison<int[]> compaprer;
        public CompareByDelegate(Comparison<int[]> del)
        {
            compaprer = del;
        }
        public int Compare(int[] arr1, int[] arr2)
        {
            return compaprer(arr1, arr2);
        }
    }

    /// <summary>
    /// Class sort matrix by bubble sort
    /// </summary>
    public static class BubbleMatrixSortDeleagteToInterface
    {
        /// <summary>
        /// Class sort matrix by choosen principle
        /// </summary>
        /// <param name="matrix">Unsorted matrix</param>
        /// <param name="comparer">Sort principle</param>
        public static void Sort(int[][] matrix, IComparer comparer)
        {
            if ((matrix == null)||(comparer == null)) throw new ArgumentNullException();
            for (int i = 0; i < (matrix.Length - 1); i++)
                for (int j = 0; j < (matrix.Length - 1 - i); j++)
                    if (comparer.Compare(matrix[j], matrix[j + 1]) > 0)
                        Swap(ref matrix[j], ref matrix[j+1]);
        }
        /// <summary>
        /// Class sort matrix by choosen principle
        /// </summary>
        /// <param name="matrix">Unsorted matrix</param>
        /// <param name="comparer">Sort principle</param>
        public static void Sort(int[][] matrix, Comparison<int[]> comparer)
        {
            if ((matrix == null) || (comparer == null)) throw new ArgumentNullException();
            Sort(matrix, (new CompareByDelegate(comparer)));
        }

        /// <summary>
        /// Swap to elements
        /// </summary>
        /// <param name="arr1">First element</param>
        /// <param name="arr2">Second element</param>
        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

    }


    /// <summary>
    /// Class sort matrix by bubble sort
    /// </summary>
    public static class BubbleMatrixSortInterfaceToDelegate
    {
        /// <summary>
        /// Class sort matrix by choosen principle
        /// </summary>
        /// <param name="matrix">Unsorted matrix</param>
        /// <param name="comparer">Sort principle</param>
        public static void Sort(int[][] matrix, IComparer comparer)
        {
            if ((matrix == null) || (comparer == null)) throw new ArgumentNullException();
            Sort(matrix, comparer.Compare);
        }
        /// <summary>
        /// Class sort matrix by choosen principle
        /// </summary>
        /// <param name="matrix">Unsorted matrix</param>
        /// <param name="comparer">Sort principle</param>
        public static void Sort(int[][] matrix, Comparison<int[]> comparer)
        {
            if ((matrix == null) || (comparer == null)) throw new ArgumentNullException();
            for (int i = 0; i < (matrix.Length - 1); i++)
                for (int j = 0; j < (matrix.Length - 1 - i); j++)
                    if (comparer(matrix[j], matrix[j + 1]) > 0)
                        Swap(ref matrix[j], ref matrix[j + 1]);
        }

        /// <summary>
        /// Swap to elements
        /// </summary>
        /// <param name="arr1">First element</param>
        /// <param name="arr2">Second element</param>
        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

    }
}
