using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.GraphTraversal.Model
{
    public interface IWeightedMetricGraph<TNode, TCost> : IWeightedGraph<TNode, TCost>, IMetricGraph<TNode, TCost>
        where TCost : IComparable<TCost>
    {
    }
}
