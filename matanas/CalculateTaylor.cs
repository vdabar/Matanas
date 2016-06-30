using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matanas.nodes;
using matanas.nodes.intefaces;
using matanas.sign.interfaces;
using matanas.EquationBuilder;

namespace matanas
{
    class CalculateTaylor
    {
       
        private List<IOperator> operators;
        private int limit;
        private int accuracy;
        
        public CalculateTaylor()
        {
            
            Initialize();
        }
        private void Initialize()
        {
            Console.WriteLine("Įveskite kur eina x:");
            string limits = Console.ReadLine();
            Console.WriteLine("Įveskite tikslumą:");
            string accuracys = Console.ReadLine();
            this.limit = Int32.Parse(limits);
            this.accuracy = Int32.Parse(accuracys);
            Equation eq = new Equation(accuracy,limit);
            operators = eq.AddFirstNode();
            Calculate();
        }
        public void Calculate()
        {
            if (checkBruteForce())
            {
                DoOperations dp = new DoOperations(operators);
                var nodes = dp.SimplifyNodes();
                Console.WriteLine(nodes.value);
            }
            else if (checkTaylor())
            {
                DoOperations dp = new DoOperations(operators);
                var nodes = dp.SimplifyNodes();
                var value = CalculateValues(nodes);
                Console.WriteLine(value);
            }
            else Console.WriteLine(("diverges"));

            Console.WriteLine("Norint pradėti iš naujo spauskite ENTER");
            Console.ReadLine();
            Initialize();
        }
        public bool checkTaylor()
        {
            double value = 0;
            List<IOperator> SortedList = operators.OrderBy(o => o.getPriority()).ToList();
            
            foreach (var op in SortedList)
            {

                var counter = op.GetNodeB().nodes.Count();
                foreach (XFormNode x in op.GetNodeB().nodes)
                {

                    value += x.GetA() * Math.Pow(limit, x.GetB());

                    if ((counter == 1))
                    {
                        foreach (XFormNode y in op.GetNodeA().nodes)
                        {
                            if ((x.GetA()!=0)&& (y.GetA()!=0)&&(x.GetB() == y.GetB())){
                                return true;
                            }
                        }
                    }
                }
                if (value != 0)
                    return true;              
            }
            return false;
        }
        public bool checkBruteForce()
        {
             List<IOperator> SortedList = operators.OrderBy(o => o.getPriority()).ToList();
            foreach (var op in SortedList)
            {
                if ((op.getPriority()==0)&&(op.GetNodeB().value==0)) {                 
                    return false;
                }
            }
            return true;
        }
        private double CalculateValues(INode item)
        {
            double value = 0 ;
            List<XFormNode> listOfNodes = item.nodes;
            foreach (XFormNode node in listOfNodes)
            {
                value += node.GetA() * Math.Pow(limit, node.GetB());
            }
            return value;
        }
        
        //public double? Calculate()
        //{
        //    foreach (var node in upper)
        //    {
        //        node.CalculateExtansion();
        //    }
        //    foreach (var node in lower)
        //    {
        //        node.CalculateExtansion();
        //    }
        //    calcOperations(upper,upperOperators);
        //    calcOperations(lower,lowerOperators);
        //    foreach (var upperItem in upper)
        //    {
        //        foreach (var lowerItem in lower)
        //        {
        //            if ((upperItem.nodes.Count == 1) && (lowerItem.nodes.Count == 1) &&
        //                ((lowerItem.nodes.FirstOrDefault(x => x.GetA() != 0)).GetB() ==
        //                 (upperItem.nodes.FirstOrDefault(x => x.GetA() != 0)).GetB()))
        //            {
        //                return (upperItem.nodes.FirstOrDefault(x => x.GetA() != 0)).GetA()/lowerItem.nodes.FirstOrDefault(x => x.GetA() != 0).GetA();
        //            }
        //            else if ((upperItem.nodes.Count == 0) && (lowerItem.nodes.Count !=0))
        //            {
        //                return 0;
        //            }
        //            else if ((lower.Count == 0) && (upperItem.nodes.FirstOrDefault(x => x.GetA() != 0).GetB() == 0) &&                  
        //                     (upperItem.nodes.Count == 1))
        //            {
        //                return upperItem.nodes.FirstOrDefault(x => x.GetA() != 0).GetA();
        //            }        
        //        }
        //    }
        //    return null;

        //}

        //private void calcOperations(List<INode> side, List<IOperator>  op )
        //{

        //    List<IOperator> SortedList = op.OrderBy(o => o.getPriority()).ToList();
        //    foreach (var listItem  in SortedList)
        //    {
        //        var nodes  = listItem.CalculateTaylor();
        //        side.FirstOrDefault(x => x.Equals(listItem.GetNodeB())).nodes = nodes;
        //        var nodea = listItem.GetNodeA();
        //        foreach (var o in SortedList)
        //        {
        //            if ((o.GetNodeA() == listItem.GetNodeA())) {o.SetNodeA(listItem.GetNodeB()); }
        //        }
        //        side.Remove(side.FirstOrDefault(x => x.Equals(nodea)));
                
        //    }

        //}
    }
}
