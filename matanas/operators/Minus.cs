using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matanas.nodes;
using matanas.nodes.intefaces;
using matanas.sign.interfaces;

namespace matanas.sign
{
    class Minus: IOperator
    {
        private INode nodea;
        private INode nodeb;
        private int priority = 2;

        public Minus(INode nodea, INode nodeb)
        {
            this.nodea = nodea;
            this.nodeb = nodeb;
        }

        public override List<XFormNode> CalculateTaylor()
        {
            
            List<XFormNode> simplifiedList = new List<XFormNode>();
            foreach (var itema in nodea.nodes)
            {
                foreach (var itemb in nodeb.nodes)
                {
                    if (itema.GetB() == itemb.GetB())
                    {
                        itema.MinusA(itemb.GetA());
                        itemb.MinusA(itemb.GetA());
                    }
                }

            }
            foreach (var item in nodea.nodes)
            {
                if (item.GetA() != 0.0)
                {
                    simplifiedList.Add(new XFormNode(item.GetA(), item.GetB()));
                }
            }
            foreach (var item in nodeb.nodes)
            {
                if (item.GetA() != 0.0)
                {
                    simplifiedList.Add(new XFormNode(item.GetA(), item.GetB()));
                }
            }

            return simplifiedList;
        }

        //public override List<INode> CalculateDerivative()
        //{
        //    List<INode> derivativesList = new List<INode>();
        //    var nodeADerivative = nodea.CalculateDerivative();
        //    var nodeBDerivative = nodeb.CalculateDerivative();
        //    derivativesList.Add(nodeBDerivative);
        //    derivativesList.Add(nodeADerivative);
        //    operators.Add(new Minus(nodeBDerivative, nodeBDerivative));
        //    return derivativesList;
        //}
        public override INode GetNodeB()
        {
            return nodeb;
        }

        public override void SetNodeB(INode node)
        {
            nodeb = node;
        }

        public override INode GetNodeA()
        {
            return nodea;
        }

        public override int getPriority()
        {
            return priority;
        }
        public override void SetNodeA(INode node)
        {
            nodea = node;
        }

        public override double CalculateValue(double a, double b)
        {
            return a - b;
        }
    }
}
