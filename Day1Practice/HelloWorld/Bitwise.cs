using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Bitwise
    {
        static void Main()
        {
            int a = 5, b = 3, c = -9;  // 5 = 101, 3 = 011
            Console.WriteLine("a = 5  → Binary: 0101");
            Console.WriteLine("b = 3  → Binary: 0011\n");
            Console.WriteLine("1. Bitwise AND (&):");
            Console.WriteLine(a & b); // Bitwise AND
            Console.WriteLine("\n2. Bitwise OR (|):");
            Console.WriteLine(a | b); // Bitwise OR
            Console.WriteLine("\n3. Bitwise XOR (^):");
            Console.WriteLine(a ^ b); // Bitwise XOR
            Console.WriteLine("\n3. Bitwise Negation or Complement (~):");
            Console.WriteLine(~a); // Bitwise negation
            Console.WriteLine(~c); // Bitwise negation
            //Console.WriteLine();


        }
    }
}