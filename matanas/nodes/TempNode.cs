using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matanas.nodes.intefaces;

namespace matanas.nodes
{
    class TempNode:INode
    {
        public TempNode(List<XFormNode> list)
        {
            nodes = list;
        }
        public override void CalculateExtansion()
        {
            throw new NotImplementedException();
        }


        public override double CalculateValue()
        {
            return value;
        }
    }
}
