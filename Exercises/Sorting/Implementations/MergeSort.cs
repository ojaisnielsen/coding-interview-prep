using Exercises.Sorting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Sorting.Implementations
{
    public class MergeSort<TValue> : ISort<TValue> 
        where TValue : IComparable <TValue>
    {
        public void Sort(TValue[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            var buffer = new TValue[array.Length];
            this.Sort(new ArraySegment<TValue>(array), new ArraySegment<TValue>(buffer), true);
        }

        private void Sort(ArraySegment<TValue> array, ArraySegment<TValue> output, bool inPlace)
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

        private void Merge(ArraySegment<TValue> array1, ArraySegment<TValue> array2, ArraySegment<TValue> output)
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
