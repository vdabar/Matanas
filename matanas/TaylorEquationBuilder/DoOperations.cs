using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matanas.nodes;
using matanas.nodes.intefaces;
using matanas.sign.interfaces;

namespace matanas
{
    class DoOperations
    {
        List<IOperator> operators;
        public DoOperations(List<IOperator> operators)
        {
            this.operators = operators;          
        }

        public INode SimplifyNodes()
        {
            List<IOperator> SortedList = operators.OrderBy(o => o.getPriority()).ToList();
            TempNode tempNode = null;
            foreach (var listItem in SortedList)
            {
                tempNode = new TempNode(listItem.CalculateTaylor());
                tempNode.value = listItem.CalculateValue(listItem.GetNodeA().CalculateValue(), listItem.GetNodeB().CalculateValue());
                foreach (var item in SortedList)
                {
                    if (listItem.GetNodeA() == item.GetNodeB())
                    {
                        item.SetNodeB(tempNode);
                    }
                    if (listItem.GetNodeB()==item.GetNodeA())
                    {
                        item.SetNodeA(tempNode);
                    }
                }
            }
            return tempNode;
        }

    }
}
