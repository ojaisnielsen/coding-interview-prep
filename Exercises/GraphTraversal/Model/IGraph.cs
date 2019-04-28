using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.GraphTraversal.Model
{
    public interface IGraph<TNode>
    {
        IEnumerable<TNode> GetSiblings(TNode node);
    }
}
