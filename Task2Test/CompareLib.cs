using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Test
{
    class CompareBySumUp : Task2.IComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            if ((arr1 == null) || (arr2 == null))
                throw new ArgumentNullException();
            if (ReferenceEquals(arr1, arr2)) return 0;
            if (arr1.Sum() > arr2.Sum())
                return 1;
            else if ((arr1.Sum() < arr2.Sum()))
                return -1;
            else
                return 0;
        }
    }

    class CompareBySumDown : Task2.IComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            if ((arr1 == null) || (arr2 == null))
                throw new ArgumentNullException();
            if (ReferenceEquals(arr1, arr2)) return 0;
            if (arr1.Sum() > arr2.Sum())
                return -1;
            else if ((arr1.Sum() < arr2.Sum()))
                return 1;
            else
                return 0;
        }
    }

    class CompareByMaxUp : Task2.IComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            if ((arr1 == null) || (arr2 == null))
                throw new ArgumentNullException();
            if (ReferenceEquals(arr1, arr2)) return 0;
            if (arr1.Max() > arr2.Max())
                return 1;
            else if ((arr1.Max() < arr2.Max()))
                return -1;
            else
                return 0;
        }
    }

    class CompareByMaxDown : Task2.IComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            if ((arr1 == null) || (arr2 == null))
                throw new ArgumentNullException();
            if (ReferenceEquals(arr1, arr2)) return 0;
            if (arr1.Max() > arr2.Max())
                return -1;
            else if ((arr1.Max() < arr2.Max()))
                return 1;
            else
                return 0;
        }
    }
}
