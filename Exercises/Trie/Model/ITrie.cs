using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Trie.Model
{
    public interface ITrie<TLabel>
        where TLabel : class
    {
        bool IsFinal { get; }
        TLabel Label { get; }

        ITrie<TLabel> Lookup(
    }



    public class PatriciaTrie
    {

    }

    public class PatriciaTrieNode
    {
        public bool IsFinal {get; private set;}

        private readonly List<char> sequence = new List<char>();

        private readonly List<char> childrenFirstLetters = new List<char>();
        private readonly List<PatriciaTrieNode> children = new List<PatriciaTrieNode>();

        public PatriciaTrieNode Parent {get; private set;}


        public PatriciaTrieNode(IEnumerable<char> sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException("sequence");
            }

            this.sequence.AddRange(sequence);
        }

        private void AddChild(PatriciaTrieNode child)
        {
            var index = this.childrenFirstLetters.BinarySearch(child.sequence.First());
            if (index >= 0)
            {
                throw new ArgumentException("A child with the same initial letter already exists.", "child");
            }

            index = ~index;
            this.childrenFirstLetters.Insert(index, child.sequence.First());
            this.children.Insert(index, child);
        }

        private void ReplaceChild(PatriciaTrieNode child, PatriciaTrieNode newChild)
        {
            if (child.sequence.First() != newChild.sequence.First())
            {
                throw new ArgumentException("The new child does not have the same initial letter.", "newChild");
            }

            var index = this.childrenFirstLetters.BinarySearch(child.sequence.First());
            if (index < 0)
            {
                throw new ArgumentException("The child is not present.", "child");
            }

            index = ~index;
            this.childrenFirstLetters.Insert(index, child.sequence.First());
            this.children.Insert(index, child);
        }

        public void Insert(IEnumerator<char> newSequence)
        {
            for (int i = 0; i < this.sequence.Count; ++i)
            {
                if (newSequence.MoveNext())
                {
                }
                else
                {
                    var newParent = new PatriciaTrieNode(this.sequence.Take(i));
                    newParent.children.Add(this);
                    newParent.childrenFirstLetters.Add(this.sequence[i]);

                    this.Parent.children.A

                    var newChild = new PatriciaTrieNode(this.sequence.Skip(i));
                    newChild.children.AddRange(this.children);
                    newChild.childrenFirstLetters.AddRange(this.childrenFirstLetters);
                    this.IsFinal = true;
                    this.sequence = this.sequenc
                }
            }




            int i = 0;
            while (newSequence.MoveNext())
            {
                if (i < this.sequence.Count)
                {
                }
                else
                {
                    break;
                }
                if (this.sequence[i] == newSequence.Current)
                {
                    ++i;
                }
                else
                {
                    break;
                }
            }

            if (newSequence.

            if (i == this.sequence.Count)
            {
                var index = this.childrenFirstLetters.BinarySearch(newSequence.Current);

                if (!newSequence.MoveNext())
                {
                    this.IsFinal = true;
                    return;
                }

                if (index >= 0)
                {
                    this.children[index].Insert(newSequence);
                }
            }


            while (i < this.sequence.Count &&)


            if (!this.sequence.Any())
            {
                this.sequence.in.AddRange(sequence);
                this.IsFinal = true;
            }
            else
            {

            }
        }

    }
}
