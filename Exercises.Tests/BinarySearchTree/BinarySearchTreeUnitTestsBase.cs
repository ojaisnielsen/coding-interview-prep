using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercises.BinarySearchTree;
using Exercises.BinarySearchTree.Model;
using System.Collections.Generic;

namespace Exercises.Tests.BinarySearchTree
{
    [TestClass]
    public abstract class BinarySearchTreeUnitTestsBase<TLabel>
        where TLabel : IComparable<TLabel>
    {
        [TestMethod]
        public void Find_OnPresentElement_Found()
        {
            var random = new Random();
            var data = this.GenerateData(100).ToList();
            var tree = this.CreateTree(data);

            Assert.IsTrue(tree.Find(data[random.Next(data.Count)]));
        }

        [TestMethod]
        public void Find_OnMissingElement_NotFound()
        {
            var random = new Random();
            var data = new HashSet<TLabel>(this.GenerateData(100));
            var element = data.ElementAt(random.Next(data.Count));
            data.Remove(element);
            var tree = this.CreateTree(data);

            Assert.IsFalse(tree.Find(element));
        }

        [TestMethod]
        public void DeleteAndFind_OnPresentElement_FoundThenNotFound()
        {
            var random = new Random();
            var data = this.GenerateData(100).ToList();
            var element = data[random.Next(data.Count)];
            var tree = this.CreateTree(data);

            Assert.IsTrue(tree.Find(element));

            tree.Remove(element);

            Assert.IsFalse(tree.Find(element));
        }

        private IBinarySearchTree<TLabel> CreateTree(IEnumerable<TLabel> values)
        {
            IBinarySearchTree<TLabel> tree = null;
            foreach (var value in values)
            {
                if (tree == null)
                {
                    tree = this.CreateTree(value);
                }
                else
                {
                    tree.Insert(value);
                }
            }

            return tree;
        }

        protected abstract IEnumerable<TLabel> GenerateData(int count);
        protected abstract IBinarySearchTree<TLabel> CreateTree(TLabel firstValue);
    }
}
