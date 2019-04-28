using Exercises.GraphTraversal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.GraphTraversal.Implementations
{
    public class DepthFirstTraverse<TNode> : SimpleTraverseBase<TNode>
    {
        private readonly Stack<TNode> stack = new Stack<TNode>();

        protected override void PushNode(TNode node)
        {
            this.stack.Push(node);
        }

        protected override TNode PopNode()
        {
            return this.stack.Pop();
        }

        protected override bool IsFinished
        {
            get
            {
                return this.stack.Count == 0;
            }
        }
    }
}
