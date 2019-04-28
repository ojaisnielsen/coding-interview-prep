using Exercises.Trie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Trie.Implementations
{
    public class SimpleTrie<TLabel> : ITrie<TLabel>
        where TLabel : class
    {
        public bool IsFinal
        {
            get;
            private set;
        }

        public TLabel Label
        {
            get;
        }

        public ITrie<TLabel> Lookup(char c)
        {
            throw new NotImplementedException();
        }
    }
}
