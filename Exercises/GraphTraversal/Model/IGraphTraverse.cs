using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.GraphTraversal.Model
{
    public interface IGraphTraverse<TNode>
    {
        IEnumerable<TNode> Go(IGraph<TNode> graph, TNode start, TNode goal);
    }

    public interface IWeightedMetricGraphTraverse<TNode, TCost>
        where TCost : IComparable<TCost>
    {
        IEnumerable<TNode> Go(IWeightedMetricGraph<TNode, TCost> graph, TNode start, TNode goal);
    }
}
