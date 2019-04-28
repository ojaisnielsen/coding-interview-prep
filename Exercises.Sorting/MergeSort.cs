using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Sorting
{
    public class MergeSort<T> : ISort<T> where T : IComparable <T>
    {
        public void Sort(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            var buffer = new T[array.Length];
            this.Sort(new ArraySegment<T>(array), new ArraySegment<T>(buffer), true);
        }

        private void Sort(ArraySegment<T> array, ArraySegment<T> output, bool inPlace)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (output == null)
            {
                throw new ArgumentNullException("output");
            }

            if (output.Count != array.Count || output.Offset != array.Offset)
            {
                throw new ArgumentException("output");
            }

            if (array.Count <= 1)
            {
                if (!inPlace && array.Count == 1)
                {
                    output.Set(0, array.Get(0));
                }
                return;
            }

            int i = array.Count / 2;
            var segment1 = array.Segment(0, i);
            var output1 = output.Segment(0, i);
            var segment2 = array.Segment(i, array.Count - i);
            var output2 = output.Segment(i, array.Count - i);

            this.Sort(segment1, output1, !inPlace);
            this.Sort(segment2, output2, !inPlace);

            if (inPlace)
            {
                this.Merge(output1, output2, array);
            }
            else
            {
                this.Merge(segment1, segment2, output);
            }
            
        }

        private void Merge(ArraySegment<T> array1, ArraySegment<T> array2, ArraySegment<T> output)
        {
            for (int i = 0, j = 0, k = 0; k < output.Count; ++k)
            {
                if (j >= array2.Count || (i < array1.Count && array1.Get(i).CompareTo(array2.Get(j)) < 0))
                {
                    output.Set(k, array1.Get(i++));
                }
                else
                {
                    output.Set(k, array2.Get(j++));
                }
            }
        }
    }
}
