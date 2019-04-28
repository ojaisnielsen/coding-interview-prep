using Exercises.BinarySearchTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.BinarySearchTree.Implementations
{
    public class SimpleBinarySearchTree<TLabel> : IBinarySearchTree<TLabel>
        where TLabel : IComparable<TLabel>
    {
        private SimpleBinarySearchTree<TLabel> parent;

        public SimpleBinarySearchTree(TLabel label)
        {
            this.Label = label;
            this.parent = null;
        }

        private SimpleBinarySearchTree(TLabel label, SimpleBinarySearchTree<TLabel> parent)
        {
            this.Label = label;
            this.parent = parent;
        }

        public void Insert(TLabel label)
        {
            var compare = this.Label.CompareTo(label);

            if (compare < 0)
            {
                if (this.LeftChild == null)
                {
                    this.LeftChild = new SimpleBinarySearchTree<TLabel>(label, this);
                }
                else
                {
                    this.LeftChild.Insert(label);
                }
            }

            if (compare > 0)
            {
                if (this.RightChild == null)
                {
                    this.RightChild = new SimpleBinarySearchTree<TLabel>(label, this);
                }
                else
                {
                    this.RightChild.Insert(label);
                }
            }
        }

        public TLabel Label
        {
            get;
            private set;
        }

        public SimpleBinarySearchTree<TLabel> LeftChild
        {
            get;
            private set;
        }

        public SimpleBinarySearchTree<TLabel> RightChild
        {
            get;
            private set;
        }


        private SimpleBinarySearchTree<TLabel> Remove(TLabel label)
        {
            int compare = this.Label.CompareTo(label);

            if (compare < 0)
            {
                if (this.LeftChild != null)
                {
                    this.LeftChild = this.LeftChild.Remove(label);
                }

                return this;
            }

            if (compare > 0)
            {
                if (this.RightChild != null)
                {
                    this.RightChild = this.RightChild.Remove(label);
                }

                return this;
            }

            if (this.LeftChild == null)
            {
                return this.RightChild;
            }

            if (this.RightChild == null)
            {
                return this.LeftChild;
            }

            var newLabel = this.LeftChild.RightMostChild.Label;
            this.LeftChild = this.LeftChild.Remove(newLabel);
            this.Label = newLabel;

            return this;
        }

        private SimpleBinarySearchTree<TLabel> RightMostChild
        {
            get
            {
                if (this.RightChild == null)
                {
                    return this;
                }

                return this.RightChild.RightMostChild;
            }
        }

        void IBinarySearchTree<TLabel>.Remove(TLabel label)
        {
            var removed = this.Remove(label);
            if (removed == null)
            {
                throw new ArgumentException("Tree cannot be empty.", "label");
            }
        }

        IBinarySearchTree<TLabel> IBinarySearchTree<TLabel>.LeftChild
        {
            get { return this.LeftChild; }
        }

        IBinarySearchTree<TLabel> IBinarySearchTree<TLabel>.RightChild
        {
            get { return this.RightChild; }
        }
    }
}
