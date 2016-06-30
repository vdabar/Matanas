using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matanas.nodes.intefaces;
using matanas.sign.interfaces;
using matanas.nodes;
using matanas.sign;
using matanas.operators;

namespace matanas.EquationBuilder
{
    class Equation:String
    {
        
        public List<INode> allNodes = new List<INode>();
        public List<IOperator> operators = new List<IOperator>();
        public Equation(int accuracy, int riba)
        {
            this.riba = riba;
            this.accuracy = accuracy;
        }
        public List<IOperator> AddFirstNode()
        {
            bool op = false;
            Console.WriteLine("\n1.x\n" +
                              "2.skaičių\n" +
                              "3.cos(ax+b)\n" +
                              "4.sin(ax+b)\n" +
                              "5.e^ax+b\n" +
                              "6.ln(ax+b)\n" +
                              "(\n"
                              );
            Console.Write(equation);
            string choice = Console.ReadLine();
            
                switch (choice)
                {
                    case "1":
                        AddOperationToNode(CreateX(), operators);
                        op = true;
                        break;
                    case "2":
                        AddOperationToNode(CreateNumber(), operators);
                        op = true;
                        break;
                    case "3":
                        AddOperationToNode(CreateCosX(), operators);
                        op = true;
                        break;
                    case "4":
                        AddOperationToNode(CreateSinX(), operators);
                        op = true;
                        break;
                    case "5":
                        AddOperationToNode(CreateEx(), operators);
                        op = true;
                        break;
                    case "6":
                        AddOperationToNode(CreateLnX(), operators);
                        op = true;
                        break;
                    case "(":

                    equation += "(";
                    OpenParenthesis item = new OpenParenthesis(accuracy,riba);
                        item.equation = equation;
                        var ri = item.AddFirstNode();
                        equation = item.equation;
                        AddOperationToNode(ri, operators);
                        op = true;
                        break;
                default:
                    Console.WriteLine("nera tokio pasirinkimo");

                    break;
                                                  
            }           
          
            return operators;
        }
        public INode AddNode()
        {


            Console.WriteLine("\n1.x\n" +
                            "2.skaičių\n" +
                            "3.cos(ax+b)\n" +
                            "4.sin(ax+b)\n" +
                            "5.e^ax+b\n" +
                            "6.ln(ax+b)\n" +
                            "(\n"
                            );
            Console.Write(equation);
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    return CreateX();
                case "2":
                    return CreateNumber();
                case "3":
                    return CreateCosX();
                case "4":
                    return CreateSinX();
                case "5":
                    return CreateEx();
                case "6":
                    return CreateLnX();
                case "(":
                    equation += "(";
                    OpenParenthesis item = new OpenParenthesis(accuracy,riba);
                    item.equation = equation;
                    var ri = item.AddFirstNode();
                    equation = item.equation;
                    return ri;
                default:
                    Console.WriteLine("Nėra tokio pasirinkimo");
                    break;


            }
            return new X(1, 1);
        }
        
        public void AddOperationToNode(INode nodea, List<IOperator> op)
        {
         
            INode nodeb;

            Console.WriteLine("\n+\n" +
                              "-\n" +
                              "*\n" +
                              "/\n" +
                              "^\n" +
                              "=\n"
                              );
            Console.Write(equation);
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "+":
                    equation += "+";
                    nodeb = AddNode();
                    op.Add(new Plus(nodea, nodeb));
                    
                    AddOperationToNode(nodeb, op);
                    
                    break;
                case "-":
                    equation += "-";
                    nodeb = AddNode();
                    op.Add(new Minus(nodea, nodeb));
                    
                    AddOperationToNode(nodeb, op);
                    
                    break;
                case "*":
                    equation += "*";
                    nodeb = AddNode();
                    op.Add(new Multiplication(nodea, nodeb));
                   
                    AddOperationToNode(nodeb, op);
                    
                    break;
                case "/":
                    equation += "/";
                    nodeb = AddNode();
                    op.Add(new Division(nodea, nodeb));
                   
                    AddOperationToNode(nodeb, op);
                    
                    break;
                case "^":
                    equation += "^";
                    nodeb = CreateNumber();
                    var newItem = new Power(nodea, nodeb);
                    op.Add(newItem);                  
                    AddOperationToNode(nodeb, op);
                    
                    break;
                case "=":
                    nodeb = new Number(0);
                    equation += "=";
                    op.Add(new Plus(nodea, nodeb));         
                    return;
                default:
                    Console.WriteLine("nera tokio pasirinkimo");

                    break;
            }
        }
     
    }
}
