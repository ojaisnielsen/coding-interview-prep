using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.GraphTraversal.Model
{
    public interface IMetricGraph<TNode, TDist> : IGraph<TNode>
        where TDist : IComparable<TDist>
    {
        TDist Distance(TNode node1, TNode node2);
    }
}
