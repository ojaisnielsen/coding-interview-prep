using Exercises.BinarySearchTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.BinarySearchTree
{
    public static class Extensions
    {
        public static bool Find<TLabel>(this IBinarySearchTree<TLabel> tree, TLabel item)
            where TLabel : IComparable<TLabel>
        {
            var compare = tree.Label.CompareTo(item);
            if (compare == 0)
            {
                return true;
            }

            if (compare < 0)
            {
                return tree.LeftChild == null ? false : tree.LeftChild.Find(item);
            }

            return tree.RightChild == null ? false : tree.RightChild.Find(item);
        }
    }
}
