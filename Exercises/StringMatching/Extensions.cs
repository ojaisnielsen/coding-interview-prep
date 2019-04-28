using Exercises.StringMatching.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.StringMatching
{
    public static class Extensions
    {
        public static int IndexOfFirst(this IStringMatch stringMatch, string text)
        {
            if (stringMatch == null)
            {
                throw new ArgumentNullException("stringMatch");
            }

            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            for (int i = 0; i < text.Length; ++i)
            {
                stringMatch.Next(text[i]);
                if (stringMatch.IsFinal)
                {
                    return i - stringMatch.Length + 1;
                }
            }

            return -1;
        }

        public static IEnumerable<string> Prefixes(this string word)
        {
            for (int i = 0; i <= word.Length; ++i)
            {
                yield return word.Substring(0, i);
            }
        }
    }
}
