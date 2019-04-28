using Exercises.GraphTraversal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.GraphTraversal.Implementations
{
    public abstract class SimpleTraverseBase<TNode> : IGraphTraverse<TNode>
    {
        public IEnumerable<TNode> Go(IGraph<TNode> graph, TNode start, TNode goal)
        {
            var markedNodes = new HashSet<TNode>();
            this.PushNode(start);
            markedNodes.Add(start);

            while (!this.IsFinished)
            {
                var node = this.PopNode();
                yield return node;

                if (node.Equals(goal))
                {
                    yield break;
                }

                foreach (var sibling in graph.GetSiblings(node))
                {
                    if (!markedNodes.Contains(sibling))
                    {
                        markedNodes.Add(sibling);
                        this.PushNode(sibling);
                    }
                }
            }
        }

        protected abstract void PushNode(TNode node);
        protected abstract TNode PopNode();
        protected abstract bool IsFinished { get; }
    }
}
