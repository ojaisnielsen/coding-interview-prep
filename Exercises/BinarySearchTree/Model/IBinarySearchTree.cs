using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.BinarySearchTree.Model
{
    public interface IBinarySearchTree<TLabel>
        where TLabel : IComparable<TLabel>
    {
        void Insert(TLabel label);
        void Remove(TLabel label);
        TLabel Label { get; }
        IBinarySearchTree<TLabel> LeftChild { get; }
        IBinarySearchTree<TLabel> RightChild { get; }
    }
}
