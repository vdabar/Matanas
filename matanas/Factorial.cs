using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matanas
{
    class Factorial
    {
        public static int factorial(int n)
        {
            if (n == 0) return 1;
            return n * factorial(n - 1);
        }
    }
}
