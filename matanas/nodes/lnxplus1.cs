using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matanas.nodes.intefaces;

namespace matanas.nodes
{
    class lnxplus1:INode
    {
        private double x,a;
        public lnxplus1(double x, double a, double b) // ln(ax+b)
        {
            this.x = x+b;
            this.a = a;
            value = Math.Log(x); 
        }

        //public override INode CalculateDerivative()
        //{
        //    throw new NotImplementedException();
        //}

        public override void CalculateExtansion()
        {
            int sign = -1;
            int p = 1;
            double vala;
            int i = 0;
            double nodeValue = 0;
            double lnValue = 0;
            while (p <= Degree)
            {
                vala = Math.Pow(sign, i) * Math.Pow(a, p) / p;
                nodes.Add(new XFormNode(vala, p));
                nodeValue = vala * Math.Pow(x, p);
                lnValue += nodeValue;
                i += 1;
                p += 1;
            }
        }
        

        public override double CalculateValue()
        {
            return Math.Log(x, Math.E);
        }
    }
}
