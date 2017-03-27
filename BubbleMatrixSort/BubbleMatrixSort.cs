using System;
using System.Linq;

namespace Task2
{
    /// <summary>
    /// Class sort matrix by bubble sort
    /// </summary>
    public static class BubbleMatrixSort
    {
        #region SortByElementSum
        /// <summary>
        /// Sorts in ascending order the sums of elements of rows of the matrix
        /// </summary>
        /// <param name="matrix">Unsoted matrix</param>
        public static void SortByElementSumUp(int[][] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();

            for(int i = 0; i < (matrix.Length - 1); i++)
                for (int j = 0; j< (matrix.Length - 1 - i); j++)
                    if ( matrix[j].Sum() > matrix[j+1].Sum())
                    {
                        int[] temp = matrix[j];
                        matrix[j] = matrix[j+1];
                        matrix[j + 1] = temp;
                    } 
        }

        /// <summary>
        /// Sorts in decreasing order the sums of elements of rows of the matrix
        /// </summary>
        /// <param name="matrix">Unsoted matrix</param>
        public static void SortByElementSumDown(int[][] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();

            for (int i = 0; i < (matrix.Length - 1); i++)
                for (int j = 0; j < (matrix.Length - 1 - i); j++)
                    if (matrix[j].Sum() < matrix[j + 1].Sum())
                    {
                        int[] temp = matrix[j];
                        matrix[j] = matrix[j + 1];
                        matrix[j + 1] = temp;
                    }
        }
        #endregion

        #region SortByMaxElement
        /// <summary>
        /// Sorts in ascending order the maximum elements of rows of the matrix
        /// </summary>
        /// <param name="matrix">Unsoted matrix</param>
        public static void SortByMaxElementUp(int[][] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();

            for (int i = 0; i < (matrix.Length - 1); i++)
                for (int j = 0; j < (matrix.Length - 1 - i); j++)  
                    if(matrix[j].Max() > matrix[j+1].Max())
                    {
                        int[] temp = matrix[j];
                        matrix[j] = matrix[j + 1];
                        matrix[j + 1] = temp;
                    }

        }

        /// <summary>
        /// Sorts in decreasing order the maximum elements of rows of the matrix
        /// </summary>
        /// <param name="matrix">Unsoted matrix</param>
        public static void SortByMaxElementDown(int[][] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();

            for (int i = 0; i < (matrix.Length - 1); i++)
                for (int j = 0; j < (matrix.Length - 1 - i); j++)
                    if (matrix[j].Max() < matrix[j + 1].Max())
                    {
                        int[] temp = matrix[j];
                        matrix[j] = matrix[j + 1];
                        matrix[j + 1] = temp;
                    }
        }
        #endregion

        #region SortByMinElement
        /// <summary>
        /// Sorts in ascending order the minimum elements of rows of the matrix
        /// </summary>
        /// <param name="matrix">Unsoted matrix</param>
        public static void SortByMinElementUp(int[][] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();

            for (int i = 0; i < (matrix.Length - 1); i++)
                for (int j = 0; j < (matrix.Length - 1 - i); j++)
                    if (matrix[j].Min() < matrix[j + 1].Min())
                    {
                        int[] temp = matrix[j];
                        matrix[j] = matrix[j + 1];
                        matrix[j + 1] = temp;
                    }
        }

        /// <summary>
        /// Sorts in decreasing order the minimum elements of rows of the matrix
        /// </summary>
        /// <param name="matrix">Unsoted matrix</param>
        public static void SortByMinElementDown(int[][] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();

            for (int i = 0; i < (matrix.Length - 1); i++)
                for (int j = 0; j < (matrix.Length - 1 - i); j++)
                    if (matrix[j].Min() > matrix[j + 1].Min())
                    {
                        int[] temp = matrix[j];
                        matrix[j] = matrix[j + 1];
                        matrix[j + 1] = temp;
                    }
        }
        #endregion



    }
}
