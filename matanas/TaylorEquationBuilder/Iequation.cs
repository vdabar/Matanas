using matanas.nodes;
using matanas.nodes.intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matanas.EquationBuilder
{
    abstract class String
    {
        public int accuracy;
        public string equation;
        public int riba;
        public INode CreateX()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("įveskite laipsnio skaičių: ");
            string input = Console.ReadLine();
            while (Int32.Parse(input) > accuracy)
            {
                Console.WriteLine("Laipsnis per didelis ");
                Console.WriteLine("įveskite laipsnio skaičių: ");
                input = Console.ReadLine();
            }
            Console.WriteLine("-------------------");
            var newItem = new X(riba, Int32.Parse(input));
            newItem.Degree = accuracy;
            newItem.CalculateExtansion();
            equation += "x^"+ input;
            
            return newItem;
        }
        public INode CreateNumber()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("įveskite skaičių: ");
            string input = Console.ReadLine();
            Console.WriteLine("-------------------");
            var x = Int32.Parse(input);
            var newItem = new Number(x);
            newItem.Degree = accuracy;
            newItem.CalculateExtansion();
            equation += input;
            return newItem;
        }
        public INode CreateSinX()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("įveskite skaičių a: ");
            string input = Console.ReadLine();
            var a = Double.Parse(input);
            Console.WriteLine("įveskite skaičių b: ");
            input = Console.ReadLine();
            var b = Double.Parse(input);
            Console.WriteLine("-------------------");
            var newItem = new Sinx(riba,a,b);
            newItem.Degree = accuracy; ;
            newItem.CalculateExtansion();
            equation += ("sin(" + a + "x" + "+" + b + ")");
            Console.Write(equation);
            return newItem;
        }
        public INode CreateCosX()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("įveskite skaičių a: ");
            string input = Console.ReadLine();
            var a = Double.Parse(input);
            Console.WriteLine("įveskite skaičių b: ");
            input = Console.ReadLine();
            var b = Double.Parse(input);
            Console.WriteLine("-------------------");
            var newItem = new Cosx(riba,a,b);
            newItem.Degree = accuracy;
            newItem.CalculateExtansion();
            equation += ("cos(" + a + "x" + "+" + b + ")");
            Console.Write(equation);
            return newItem;
        }
        public INode CreateEx()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("E^ax^b įveskite b: ");
            string input = Console.ReadLine();
            var laipsnis = Int32.Parse(input);

            Console.WriteLine("E^ax^b įveskite a: ");
            input = Console.ReadLine();
            var koficientas = Double.Parse(input);
            Console.WriteLine("-------------------");
            var newItem = new Ex(riba, koficientas, laipsnis, 1);
            newItem.Degree = accuracy;
            newItem.CalculateExtansion();
            equation += "e^" + koficientas + "x^" + laipsnis;
            Console.Write(equation);
            return newItem;
        }
        public INode CreateLnX()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("įveskite skaičių a: ");
            string input = Console.ReadLine();
            var a = Double.Parse(input);
            Console.WriteLine("įveskite skaičių b: ");
            input = Console.ReadLine();
            var b = Double.Parse(input);
            Console.WriteLine("-------------------");
            var newItem = new lnxplus1(riba,a,b);
            newItem.Degree = accuracy;
            newItem.CalculateExtansion();
            equation += ("ln("+a+"x"+"+"+ b+")");
            Console.Write(equation);
            return newItem;
        }
    }
}
