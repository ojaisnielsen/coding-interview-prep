using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Sorting.Tests
{
    [TestClass]
    public class MergeSortIntUnitTests : SortIntUnitTests<MergeSort<int>>
    {
        protected override ISort<int> CreateSort()
        {
            return new MergeSort<int>();
        }
    }
}
