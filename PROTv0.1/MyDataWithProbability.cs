using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROTv0._1
{
    /// <summary>
    /// Answer that has a certain probability of appearing
    /// </summary>
    internal class MyDataWithProbability :MyData
    {
       public double probability { get; set; }

        public MyDataWithProbability(string text, int priz, bool isNeg, bool isTrue, double probability) : base(text, priz, isNeg, isTrue)
        {
            this.probability = probability;
        }
    }
}
