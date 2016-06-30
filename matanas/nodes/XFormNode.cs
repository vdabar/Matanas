using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matanas.nodes
{
    class XFormNode
    {
        private double a;
        private int b;
        public XFormNode(double a, int b)  //skaicius formatu ax^b 
        {
            this.a = a;
            this.b = b;
        }

        public double GetA()
        {
            return a;
        }

        public int GetB()
        {
            return b;
        }

        public void PlusA(double value)
        {
            a += value;
        }
        public void MinusA(double value)
        {
            a -= value;
        }

        public void Clear()
        {
            a = 0;
            b = 0;
        }
    }
}
