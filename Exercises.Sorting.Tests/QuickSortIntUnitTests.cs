using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Sorting.Tests
{
    [TestClass]
    public class QuickSortIntUnitTests : SortIntUnitTests<QuickSort<int>>
    {
        protected override ISort<int> CreateSort()
        {
            return new QuickSort<int>();
        }
    }
}
