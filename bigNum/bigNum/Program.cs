using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigNum
{
    class Program
    {
        static void Main(string[] args)
        {
            BigNum n1 = new BigNum("00000000000000036919");
            BigNum n2 = new BigNum("00000000000000000929");
 
             Console.WriteLine(n1.Multiplication(n2));
        }
    }
}
