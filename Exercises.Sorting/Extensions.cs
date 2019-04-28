using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Sorting
{
    public static class Extensions
    {
        public static T Get<T>(this ArraySegment<T> array, int i)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (i < 0 || i >= array.Count)
            {
                throw new ArgumentOutOfRangeException("i");
            }

            return array.Array[array.Offset + i];
        }

        public static void Set<T>(this ArraySegment<T> array, int i, T value)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (i < 0 || i >= array.Count)
            {
                throw new ArgumentOutOfRangeException("i");
            }

            array.Array[array.Offset + i] = value;
        }

        public static void Swap<T>(this ArraySegment<T> array, int i, int j)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (i < 0 || i >= array.Count)
            {
                throw new ArgumentOutOfRangeException("i");
            }

            if (j < 0 || j >= array.Count)
            {
                throw new ArgumentOutOfRangeException("j");
            }

            var temp = array.Get(i);
            array.Set(i, array.Get(j));
            array.Set(j, temp);
        }

        public static ArraySegment<T> Segment<T>(this ArraySegment<T> array, int offset, int count)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (offset < 0 || offset >= array.Count)
            {
                throw new ArgumentOutOfRangeException("offset");
            }

            if (count < 0 || offset + count > array.Count)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            return new ArraySegment<T>(array.Array, array.Offset + offset, count);
        }
    }
}
