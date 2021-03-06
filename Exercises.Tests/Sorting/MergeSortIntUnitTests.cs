﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercises.Sorting;
using Exercises.Sorting.Implementations;
using Exercises.Sorting.Model;

namespace Exercises.Tests.Sorting
{
    [TestClass]
    public class MergeSortIntUnitTests : SortIntUnitTestsBase
    {
        protected override ISort<int> CreateSort()
        {
            return new MergeSort<int>();
        }
    }
}
