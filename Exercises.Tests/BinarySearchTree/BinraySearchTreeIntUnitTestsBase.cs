using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.Tests.BinarySearchTree
{
    [TestClass]
    public abstract class BinraySearchTreeIntUnitTestsBase : BinarySearchTreeUnitTestsBase<int>
    {
        protected override IEnumerable<int> GenerateData(int count)
        {
            var random = new Random();
            return Enumerable.Range(0, count).Select(i => random.Next());
        }
    }
}
