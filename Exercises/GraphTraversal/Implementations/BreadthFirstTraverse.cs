using Exercises.GraphTraversal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.GraphTraversal.Implementations
{
    public class BreadthFirstTraverse<TNode> : SimpleTraverseBase<TNode>
    {
        private readonly Queue<TNode> queue = new Queue<TNode>();

        protected override void PushNode(TNode node)
        {
            this.queue.Enqueue(node);
        }

        protected override TNode PopNode()
        {
            return this.queue.Dequeue();
        }

        protected override bool IsFinished
        {
            get
            {
                return this.queue.Count == 0;
            }
        }
    }
}
