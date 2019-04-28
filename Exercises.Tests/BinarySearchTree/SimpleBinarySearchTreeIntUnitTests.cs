using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Exercises.BinarySearchTree.Model;
using Exercises.BinarySearchTree.Implementations;

namespace Exercises.Tests.BinarySearchTree
{
    [TestClass]
    public class SimpleBinarySearchTreeIntUnitTests : BinraySearchTreeIntUnitTestsBase
    {
        protected override IBinarySearchTree<int> CreateTree(int value)
        {
            return new SimpleBinarySearchTree<int>(value);
        }
    }
}
