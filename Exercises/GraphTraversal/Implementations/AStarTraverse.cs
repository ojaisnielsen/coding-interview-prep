using Exercises.GraphTraversal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.GraphTraversal.Implementations
{
    public class AStarTraverse<TNode, TCost> : IWeightedMetricGraphTraverse<TNode, TCost>
        where TCost : IComparable<TCost>
    {
        private readonly HashSet<TNode> closedSet = new HashSet<TNode>();
        private readonly List<TNode> openSet = new List<TNode>();
        private readonly List<TCost> estimatedCosts = new List<TCost>();
        private readonly Dictionary<TNode, TNode> precedence = new Dictionary<TNode, TNode>();
        private readonly Dictionary<TNode, TCost> currentCosts = new Dictionary<TNode, TCost>();

        public IEnumerable<TNode> Go(IWeightedMetricGraph<TNode, TCost> graph, TNode start, TNode goal)
        {
            this.closedSet.Clear();
            this.openSet.Clear();
            this.precedence.Clear();
            this.currentCosts.Clear();
            this.estimatedCosts.Clear();

            this.openSet.Add(start);
            this.estimatedCosts.Add(graph.Distance(start, goal));
            this.currentCosts[start] = graph.Zero;

            while (this.openSet.Any())
            {
                var current = this.openSet.First();

                if (current.Equals(goal))
                {
                    return this.ReconstructPath(current);
                }

                this.estimatedCosts.RemoveAt(0);
                this.openSet.RemoveAt(0);
                this.closedSet.Add(current);

                foreach (var sibling in graph.GetSiblingCosts(current))
                {
                    var tentative = graph.Add(this.currentCosts[current], sibling.Value);

                    if (this.closedSet.Contains(sibling.Key) && tentative.CompareTo(this.currentCosts[sibling.Key]) >= 0)
                    {
                        continue;
                    }

                    var indexInOpenSet = this.openSet.IndexOf(sibling.Key);

                    if (indexInOpenSet < 0 || tentative.CompareTo(this.currentCosts[sibling.Key]) < 0)
                    {
                        if (indexInOpenSet >= 0)
                        {
                            openSet.RemoveAt(indexInOpenSet);
                            this.estimatedCosts.RemoveAt(indexInOpenSet);
                        }

                        this.precedence[sibling.Key] = current;
                        this.currentCosts[sibling.Key] = tentative;
                        var estimatedTotalCost = graph.Add(tentative, graph.Distance(sibling.Key, goal));
                        var index = this.estimatedCosts.BinarySearch(estimatedTotalCost);

                        if (index < 0)
                        {
                            index = ~index;
                        }

                        this.estimatedCosts.Insert(index, estimatedTotalCost);
                        this.openSet.Insert(index, sibling.Key);
                    }
                }
            }

            throw new ArgumentException();
        }

        private IEnumerable<TNode> ReconstructPath(TNode node)
        {
            if (this.precedence.ContainsKey(node))
            {
                foreach (var previousNode in ReconstructPath(this.precedence[node]))
                {

                    yield return previousNode;
                }
            }

            yield return node;
        }
    }

    public class AStarTraverse<TNode> : IGraphTraverse<TNode>
    {
        private class WeightedMetricGraphWrapper : IWeightedMetricGraph<TNode, int>
        {
            private readonly IGraph<TNode> baseGraph;
            public WeightedMetricGraphWrapper(IGraph<TNode> baseGraph)
            {
                this.baseGraph = baseGraph;
            }

            public IEnumerable<KeyValuePair<TNode, int>> GetSiblingCosts(TNode node)
            {
                return from sibling in this.baseGraph.GetSiblings(node) select new KeyValuePair<TNode, int>(sibling, 1);
            }

            public int Add(int cost1, int cost2)
            {
                return cost1 + cost2;
            }

            public int Zero
            {
                get { return 0; }
            }

            public IEnumerable<TNode> GetSiblings(TNode node)
            {
                return this.baseGraph.GetSiblings(node);
            }

            public int Distance(TNode node1, TNode node2)
            {
                return 0;
            }
        }

        private readonly AStarTraverse<TNode, int> baseTraverse = new AStarTraverse<TNode, int>();

        public IEnumerable<TNode> Go(IGraph<TNode> graph, TNode start, TNode goal)
        {
            return this.baseTraverse.Go(new WeightedMetricGraphWrapper(graph), start, goal);
        }
    }
}
