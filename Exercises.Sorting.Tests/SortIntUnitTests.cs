using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Sorting.Tests
{
    [TestClass]
    public abstract class SortIntUnitTests<T> : SortUnitTests<T, int> where T: ISort<int>
    {
        protected override int[] GenerateData()
        {
            var data = new int[10];
            var random = new Random();
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = random.Next();
            }

            return data;
        }

        protected abstract override ISort<int> CreateSort();
    }
}
