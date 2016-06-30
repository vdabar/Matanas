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
    class Multiplication:IOperator
    {
        private INode nodea;
        private INode nodeb;
        private int priority = 1;
        

        public Multiplication(INode nodea, INode nodeb)
        {
            this.nodea = nodea;
            this.nodeb = nodeb;
        }

        public override List<XFormNode> CalculateTaylor()
        {
            double a1,a2;
            int b1,b2;
            List<XFormNode> multiplicatedList = new List<XFormNode>();
            foreach (var x in nodea.nodes)
            {
                foreach (var y in nodeb.nodes)
                {
                    a1 = x.GetA();
                    b1 = x.GetB();
                    a2 = y.GetA();
                    b2 = y.GetB();
                    multiplicatedList.Add(new XFormNode(a1*a2,b1+b2));
                }
            }
            return Simplify(multiplicatedList);
        }

        //public override List<INode> CalculateDerivative()
        //{
        //    List<INode> derivativesList = new List<INode>();
        //    derivativesList.Add(nodea);
        //    derivativesList.Add(nodeb);
        //    var nodeADerivative = nodea.CalculateDerivative();
        //    var nodeBDerivative = nodeb.CalculateDerivative();
        //    derivativesList.Add(nodeBDerivative);
        //    derivativesList.Add(nodeADerivative);
        //    operators.Add(new Multiplication(nodeADerivative,nodeb));
        //    operators.Add(new Multiplication(nodeBDerivative,nodea));
        //    operators.Add(new Plus(nodea,nodeb));
        //    return derivativesList;

        //}
        private List<XFormNode> Simplify(List<XFormNode> list)
        {
            List<XFormNode> simplifiedList = new List<XFormNode>();
            int maxDegree = 0;
            foreach (var item in list)
            {
                if (item.GetB() > maxDegree)
                {
                    maxDegree = item.GetB();
                }
            }
            for (int i = 0; i <= maxDegree; i++)
            {
                simplifiedList.Add(new XFormNode(0, i));
            }
            foreach (var simplifiedItem in simplifiedList)
            {
                foreach (var unsimplifiedItem in list)
                {
                    if (simplifiedItem.GetB() == unsimplifiedItem.GetB())
                    {
                        simplifiedItem.PlusA(unsimplifiedItem.GetA());
                    }
                }
            }
            var deleteItem = simplifiedList.FirstOrDefault(x => x.GetA() == 0);
            while (deleteItem != null)
            {
                simplifiedList.Remove(deleteItem);
                deleteItem = simplifiedList.FirstOrDefault(x => x.GetA() == 0);
            }

            return simplifiedList;
        }

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

        public override double CalculateValue(double a, double b)
        {
            return a * b;
        }

        public override void SetNodeA(INode node)
        {
            nodea = node;
        }
    }
}
