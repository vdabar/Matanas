using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matanas.nodes.intefaces;

namespace matanas.nodes
{
    class OnePlusXPowM : INode
    {
        private double x;
        private double m;
        public OnePlusXPowM(double x, double m)
        {
            this.x = x;
            this.m = m;
            value = Math.Pow(1 + x, m);
        }
        public override void CalculateExtansion()
        {
            int p = 0;
            double d = 1;
            double a = 0;
            int i = 0;
            nodes.Add(new XFormNode(1, 0));
            while (m < 0)
            {
                a =   d*(m) / Factorial.factorial(p);
                d *= m;
                nodes.Add(new XFormNode(a, p));
                m -= 1;
                i += 1;
                p += 1;
            }
        }

        //public override INode CalculateDerivative()
        //{
        //    throw new NotImplementedException();
        //}

        public override double CalculateValue()
        {
            
            return Math.Pow(1 + x, m);
        }
    }
}
