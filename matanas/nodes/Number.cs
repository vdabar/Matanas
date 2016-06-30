using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using matanas.nodes.intefaces;

namespace matanas.nodes
{
    class Number : INode
    {
        private double x;
        public Number(double x)
        {
            this.x = x;
            value = x; 
        }
        //public override INode CalculateDerivative()
        //{
        //    return new Number(x);
        //}

        public override void CalculateExtansion()
        {
            nodes.Add(new XFormNode(x,0));
        }

        public override double CalculateValue()
        {
            return x;
        }
    }
}
