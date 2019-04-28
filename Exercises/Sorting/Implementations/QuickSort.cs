using Exercises.Sorting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Sorting.Implementations
{
    public class QuickSort<TValue> : ISort<TValue> 
        where TValue : IComparable<TValue>
    {
        public void Sort(TValue[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            this.Sort(new ArraySegment<TValue>(array));
        }

        private void Sort(ArraySegment<TValue> array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (array.Count <= 1)
            {
                return;
            }

            int pivot = array.Count - 1;

            int i = 0;
            int j = pivot - 1;
            while (i <= j)
            {
                if (array.Get(i).CompareTo(array.Get(pivot)) > 0)
                {
                    array.Swap(i, j--);
                }
                else
                {
                    ++i;
                }
            }

            array.Swap(pivot, i);
            Sort(array.Segment(0, i));
            if (i < array.Count - 1)
            {
                Sort(array.Segment(i + 1, array.Count - i - 1));
            }
        }
    }
}
