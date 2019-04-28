using Exercises.Sorting;
using Exercises.Sorting.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests.Sorting
{
    [TestClass]
    public abstract class SortIntUnitTestsBase : SortUnitTestsBase<int> 
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
