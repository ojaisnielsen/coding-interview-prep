using Exercises.GraphTraversal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.GraphTraversal.Implementations
{
    public class EuclidianGridGraph : IWeightedMetricGraph<Tuple<int, int>, double>
    {
        public readonly SortedDictionary<Tuple<int, int>, SortedDictionary<Tuple<int, int>, double>> Costs = new SortedDictionary<Tuple<int, int>, SortedDictionary<Tuple<int, int>, double>>();

        public void AddEdge(int i1, int i2, int j1, int j2)
        {
            var node1 = Tuple.Create(i1, j1);
            var node2 = Tuple.Create(i2, j2);
            SortedDictionary<Tuple<int, int>, double> siblingCosts;
            if (!this.Costs.TryGetValue(node1, out siblingCosts))
            {
                siblingCosts = new SortedDictionary<Tuple<int, int>, double>();
                this.Costs[node1] = siblingCosts;
            }

            siblingCosts[node2] = this.Distance(node1, node2);

            if (!this.Costs.TryGetValue(node2, out siblingCosts))
            {
                siblingCosts = new SortedDictionary<Tuple<int, int>, double>();
                this.Costs[node2] = siblingCosts;
            }

            siblingCosts[node1] = this.Distance(node1, node2);
        }

        public IEnumerable<Tuple<int, int>> GetSiblings(Tuple<int, int> node)
        {
            SortedDictionary<Tuple<int, int>, double> siblingCosts;    
            if (this.Costs.TryGetValue(node, out siblingCosts))
            {
                return siblingCosts.Keys;
            }

            return new Tuple<int, int>[0];
        }

        public IEnumerable<KeyValuePair<Tuple<int, int>, double>> GetSiblingCosts(Tuple<int, int> node)
        {
            SortedDictionary<Tuple<int, int>, double> siblingCosts;
            if (this.Costs.TryGetValue(node, out siblingCosts))
            {
                return siblingCosts.AsEnumerable(); 
            }

            return new KeyValuePair<Tuple<int, int>, double>[0];
        }


        public double Add(double cost1, double cost2)
        {
            return cost1 + cost2;
        }

        public double Distance(Tuple<int, int> node1, Tuple<int, int> node2)
        {
            var dx = node1.Item1 - node2.Item1;
            var dy = node1.Item2 - node2.Item2;

            return Math.Sqrt((dx * dx) + (dy * dy));
        }


        public double Zero
        {
            get { return 0; }
        }
    }
}
