using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercises.GraphTraversal;
using Exercises.GraphTraversal.Implementations;
using Exercises.GraphTraversal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests.GraphTraversal
{
    [TestClass]
    public abstract class SimpleGraphTraverseUnitTestsBase : GraphTraverseUnitTestsBase<string>
    {
        protected override IGraph<string> CreateGraph()
        {
            var graph = new SimpleGraph<string>();
            graph.AddEdge("6", "4");
            graph.AddEdge("4", "3");
            graph.AddEdge("4", "5");
            graph.AddEdge("5", "2");
            graph.AddEdge("5", "1");
            graph.AddEdge("3", "2");
            graph.AddEdge("1", "2");

            return graph;
        }
    }
}
