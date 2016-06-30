using matanas.nodes.intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matanas.nodes
{
    class X:INode
    {
        
        private double a=1;
        private int b;
        private double x;
        public X(double x,int b) //ax^b
        {
            
            this.b = b;
            this.x = x;
            value = Math.Pow(x, b);
        }

        public override void CalculateExtansion()
        {
            nodes.Add(new XFormNode(a, b));
        }

        //public override INode CalculateDerivative()
        //{
        //    this.a = a*b;
        //    this.b = b - 1;
        //    var x = new X(this.x,a,b);
        //    return x;
        //}

        public override double CalculateValue()
        {
            
            return (Math.Pow(x, b));
        }
    }
}
