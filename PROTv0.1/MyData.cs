using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROTv0._1
{
    internal class MyData
    {
        public string text;
        public int priz;
        public bool isNeg;
        public bool isTrue;

        public MyData(string text, int priz, bool isNeg, bool isTrue)
        {
            this.text = text;
            this.priz = priz;
            this.isNeg = isNeg;
            this.isTrue = isTrue;
        }
    }
}
