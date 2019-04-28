using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.EditDistance.Model
{
    public interface IEditDistance
    {
        int Distance(string s1, string s2);
    }
}
