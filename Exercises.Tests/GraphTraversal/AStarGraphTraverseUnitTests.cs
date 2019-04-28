using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercises.GraphTraversal;
using Exercises.GraphTraversal.Implementations;
using Exercises.GraphTraversal.Model;
using System.Collections;
using System.IO;

namespace Exercises.Tests.GraphTraversal
{
    [TestClass]
    public class AStarGraphTraverseUnitTests : WeightedMetricGraphTraverseUnitTestsBase<Tuple<int, int>, double>
    {
        private readonly int[,] Problem = new int[,] 
                {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 15 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 14, 0 }, 
                    { 0, 0, 0, 0, 0, 0, 0, 13, 0 }, 
                    { 0, 0, 0, -1, -1, -1, -1, 12, 0 }, 
                    { 0, 0, 0, 0, 0, 0, -1, 11, 0 }, 
                    { 0, 0, 0, 0, 0, 0, -1, 10, 0 }, 
                    { 0, 0, 0, 0, 0, -1, -1, 9, 0 }, 
                    { 0, 0, 0, 0, 0, 0, -1, 8, 0 }, 
                    { 0, 0, 0, 0, 0, 6, 7, 0, 0 }, 
                    { 0, 0, 0, 0, 5, 0, 0, 0, 0 }, 
                    { 0, 0, 0, 4, 0, 0, 0, 0, 0 }, 
                    { 0, 2, 3, 0, 0, 0, 0, 0, 0 }, 
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0 }
                };

        protected override IWeightedMetricGraphTraverse<Tuple<int, int>, double> CreateTraverse()
        {
            return new AStarTraverse<Tuple<int, int>, double>();
        }

        protected override IWeightedMetricGraph<Tuple<int, int>, double> CreateGraph()
        {
            var graph = new EuclidianGridGraph();

            int m = this.Problem.GetLength(0);
            int n = this.Problem.GetLength(1);

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (this.Problem[i, j] == -1)
                    {
                        continue;
                    }

                    for (int i2 = i - 1; i2 <= i + 1; ++i2)
                    {
                        for (int j2 = j - 1; j2 <= j + 1; ++j2)
                        {
                            if ((i2 == i && j2 == i) || i2 < 0 || j2 < 0 || i2 >= m || j2 >= n)
                            {
                                continue;
                            }

                            if (this.Problem[i2, j2] >= 0)
                            {
                                graph.AddEdge(i, i2, j, j2);
                            }
                        }
                    }
                }
            }

            return graph;
        }

        protected override IList TargetOrder
        {
            get
            {
                int m = this.Problem.GetLength(0);
                int n = this.Problem.GetLength(1);

                var path = new SortedList<int, Tuple<int, int>>();

                for (int i = 0; i < m; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        if (this.Problem[i, j] <= 0)
                        {
                            continue;
                        }

                        path.Add(this.Problem[i, j], Tuple.Create(i, j));
                    }
                }

                return (IList)path.Values.ToList();
            }
        }
    }
}
