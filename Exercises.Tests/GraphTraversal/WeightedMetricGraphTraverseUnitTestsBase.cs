﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercises.GraphTraversal;
using Exercises.GraphTraversal.Implementations;
using Exercises.GraphTraversal.Model;
using System.Collections;


namespace Exercises.Tests.GraphTraversal
{
    [TestClass]
    public abstract class WeightedMetricGraphTraverseUnitTestsBase<TNode, TCost>
        where TCost : IComparable<TCost>
    {
        [TestMethod]
        public void Traverse_OnNonEmptyGraph_FromFirstToLast()
        {
            var graph = this.CreateGraph();
            var traverse = this.CreateTraverse();

            CollectionAssert.AreEqual(this.TargetOrder, traverse.Go(graph, (TNode)this.TargetOrder[0], (TNode)this.TargetOrder[this.TargetOrder.Count - 1]).ToList());
        }

        protected abstract IWeightedMetricGraphTraverse<TNode, TCost> CreateTraverse();

        protected abstract IWeightedMetricGraph<TNode, TCost> CreateGraph();

        protected abstract IList TargetOrder { get; }
    }
}
