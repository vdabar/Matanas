using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matanas.nodes;
using matanas.nodes.intefaces;

namespace matanas.sign.interfaces
{
    abstract class IOperator
    {
        public abstract List<XFormNode> CalculateTaylor();
        //public abstract List<INode> CalculateDerivative();
        public List<IOperator> operators = new List<IOperator>();
        public abstract INode GetNodeB();
        public abstract void SetNodeA(INode node);

        public abstract void SetNodeB(INode node);
        public abstract INode GetNodeA();
        public abstract int getPriority();
        public abstract double CalculateValue(double a, double b);

    }
}
