using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matanas.nodes.intefaces
{
    abstract class INode
    {
        public abstract void CalculateExtansion();       
        public List<XFormNode> nodes = new List<XFormNode>();
        public int Degree { get; set; }
        public double value = 0;
        public abstract double CalculateValue();
    }
}
