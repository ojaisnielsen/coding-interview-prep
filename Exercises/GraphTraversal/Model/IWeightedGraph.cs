using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.GraphTraversal.Model
{
    public interface IWeightedGraph<TNode, TCost> : IGraph<TNode>
        where TCost : IComparable<TCost> 
    {
        IEnumerable<KeyValuePair<TNode, TCost>> GetSiblingCosts(TNode node);
        TCost Add(TCost cost1, TCost cost2);
        TCost Zero { get; }
    }
}
