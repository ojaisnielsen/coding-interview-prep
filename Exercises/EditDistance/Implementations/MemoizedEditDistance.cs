using Exercises.EditDistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.EditDistance.Implementations
{
    public class MemoizedEditDistance : IEditDistance
    {
        private int?[,] costMatrix;
        private string s1;
        private string s2;

        public int Distance(string s1, string s2)
        {
            this.Clear(s1, s2);
            return this.GetCost(s1.Length - 1, s2.Length - 1);
        }

        private void Clear(string s1, string s2)
        {
            this.s1 = s1;
            this.s2 = s2;
            this.costMatrix = new int?[s1.Length, s2.Length];
        }

        private int GetCost(int i, int j)
        {
            if (!this.costMatrix[i, j].HasValue)
            {
                if (i == 0)
                {
                    this.costMatrix[i, j] = j;
                }
                else if (j == 0)
                {
                    this.costMatrix[i, j] = i;
                }
                else
                {
                    var costs = new int[3];
                    costs[0] = this.GetCost(i - 1, j) + 1;
                    costs[1] = this.GetCost(i, j - 1) + 1;
                    costs[2] = this.GetCost(i - 1, j - 1) + (this.s1[i] == this.s2[j] ? 0 : 1);
                    this.costMatrix[i, j] = costs.Min();
                }
            }

            return this.costMatrix[i, j].Value;
        }
    }
}
