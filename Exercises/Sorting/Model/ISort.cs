using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Sorting.Model
{
    public interface ISort<TValue> 
        where TValue : IComparable<TValue>
    {
        void Sort(TValue[] array);
    }
}
