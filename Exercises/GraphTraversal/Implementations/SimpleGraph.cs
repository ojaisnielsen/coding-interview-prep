using Exercises.GraphTraversal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.GraphTraversal.Implementations
{
    public class SimpleGraph<TNode> : IGraph<TNode>
    {
        private readonly SortedDictionary<TNode, SortedSet<TNode>> siblings = new SortedDictionary<TNode, SortedSet<TNode>>();

        public void AddEdge(TNode node1, TNode node2)
        {
            SortedSet<TNode> existingSiblings;
            if (!this.siblings.TryGetValue(node1, out existingSiblings))
            {
                existingSiblings = new SortedSet<TNode>();
                this.siblings[node1] = existingSiblings;
            }

            existingSiblings.Add(node2);

            if (!this.siblings.TryGetValue(node2, out existingSiblings))
            {
                existingSiblings = new SortedSet<TNode>();
                this.siblings[node2] = existingSiblings;
            }

            existingSiblings.Add(node1);
        }

        public IEnumerable<TNode> GetSiblings(TNode node)
        {
            return this.siblings[node];
        }
    }
}
