using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matanas.nodes.intefaces;

namespace matanas.nodes
{
    class Cosx : INode
    {
        private double x,a;
        public Cosx(double x, double a, double b)//cos(ax+b)
        {
            this.x = x+b;
            this.a = a;
            value = Math.Cos(x);

        }
        //public override INode CalculateDerivative()
        //{
        //    return new Sinx(x,-1);
        //}

        public override double CalculateValue()
        {
            
            return Math.Cos(x);
        }

        public override void CalculateExtansion()
        {
            int sign = -1;
            int p = 0;
            double d = 1;
            double cosx = 0;
            int i = 0;
            double vala = 1;
            double nodeValue = 0;
            while (p<= Degree)
            {
                vala = Math.Pow(sign, i)*1 * Math.Pow(a, p) / Factorial.factorial(p);
                nodeValue = vala * Math.Pow(x, p); 
                cosx += nodeValue;
                nodes.Add(new XFormNode(vala, p));
                i += 1;
                p += 2;             
            }

        }
         private int findN(double aprox)
        {
            double aprVal=1;
            int n = 0;
            
            while (aprVal>aprox)
            {
                aprVal = 1*a / Factorial.factorial(n + 1);
                n++;
            }
            return n;

        }
        
    }
}
