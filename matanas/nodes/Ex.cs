using System;
using System.Collections.Generic;
using matanas.nodes.intefaces;

namespace matanas.nodes
{
    class Ex : INode
    {
        private double x;
        private double y = 1;
        private int z = 1;
        private double sign; 
         
        public Ex(double x, double y, int z, double sign)   // formatas e^yx^z
        {
            this.sign = sign;
            this.x = x;
            this.y = y;
            this.z = z;
            value = Math.Pow(Math.E, y * Math.Pow(x, z));

        }

        //public override INode CalculateDerivative()
        //{
        //    return new Ex(x,y,z,sign);
        //}

        public override double CalculateValue()
        {
           
            return Math.Pow(Math.E, y*Math.Pow(x, z));
        }

        public override void CalculateExtansion()
        {
            int p = 0;
            int laipsnis = 0;
            double a;           
            double d;
            double ex = 1;
            while (laipsnis <= Degree)
            {
                a = Math.Pow(y, p)/Factorial.factorial(p);
                d = Math.Pow(y,p)*(Math.Pow(x, laipsnis)/Factorial.factorial(p));
                ex += sign * d;
                nodes.Add(new XFormNode(sign * a, laipsnis));
                Console.WriteLine(sign * a);
                p += 1;
                laipsnis = z*p;
            }
          
        }
    }
}
