using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.StringMatching.Model
{
    public interface IStringMatch
    {
        void Next(char c);
        bool IsFinal { get; }
        void Reset();
        int Length { get; }
    }
}
