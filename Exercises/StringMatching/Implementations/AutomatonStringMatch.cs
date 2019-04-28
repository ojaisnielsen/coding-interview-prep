using Exercises.StringMatching.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.StringMatching.Implementations
{
    public class AutomatonStringMatch : IStringMatch
    {
        private class State
        {          
            public bool IsFinal { get; set; }
            public readonly Dictionary<char, State> Transitions = new Dictionary<char, State>();
        }

        private readonly HashSet<char> Alphabet;
        private readonly State startState;
        private State state;

        public int Length { get; private set; }

        public AutomatonStringMatch(params string[] words)
        {
            this.Alphabet = new HashSet<char>(words.SelectMany(word => word));
            var prefixes = new HashSet<string>(words.SelectMany(word => word.Prefixes()));

            var states = new Dictionary<string, State>();
            foreach (var prefix in prefixes)
            {
                states[prefix] = new State();
            }

            foreach (var word in words)
            {
                states[word].IsFinal = true;
            }

            this.startState = states[string.Empty];

            foreach (var prefixStatePair in states)
            {
                foreach (var c in this.Alphabet)
                {
                    var maxPrefix = MaxPrefix(prefixStatePair.Key + c, prefixes);
                    if (maxPrefix.Length > 0)
                    {
                        prefixStatePair.Value.Transitions[c] = states[maxPrefix];
                    }                    
                }
            }

            this.Reset();
        }

        private static string MaxPrefix(string prefix, HashSet<string> prefixes)
        {
            for (int i = 0; i < prefix.Length; ++i)
            {
                var current = prefix.Substring(i);
                if (prefixes.Contains(current))
                {
                    return current;
                }
            }

            return string.Empty;
        }

        public void Next(char c)
        {
            State next;
            if (this.state.Transitions.TryGetValue(c, out next))
            {
                this.state = next;
                this.Length++;
            }
            else 
            {
                this.Reset();                
            }
        }

        public bool IsFinal
        {
            get { return this.state.IsFinal; }
        }

        public void Reset()
        {
            this.state = this.startState;
            this.Length = 0;
        }
    }
}
