using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Sorting
{
    public interface ISort<T> where T : IComparable<T>
    {
        void Sort(T[] array);
    }
}
