using matanas.nodes.intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matanas.nodes
{
    class Sinx :INode
    {
        private double a;
        private double x;
        public Sinx(double x, double a, double b)//sin(ax+b)
        {
            this.a = a;
            this.x = x+b;
            value = Math.Sin(x); 
        }
        //public override INode CalculateDerivative()
        //{
        //    return new Cosx(x);
        //}
        public override void CalculateExtansion()
        {
            int sign = -1;
            int p = 1;
            double d = 1;
            double nodeValue =0;
            double vala = 1;
            double sinx = 0;
            int i = 0;
            double reminder = 1 / Math.Pow(10, Degree);
            while ((p<=Degree))
            {
                vala = Math.Pow(sign, i)*1*Math.Pow(a,p) /Factorial.factorial(p);
                nodeValue = vala * Math.Pow(x, p);
                sinx += nodeValue;          
                nodes.Add(new XFormNode(vala, p));
                i += 1;
                p += 2;
            }
        }
      
        public override double CalculateValue()
        {
            var newItem = Math.Sin(x);
            return newItem;
        }
        
    }
}
