using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Custominput
    {
        static void Main()
        {
            Console.Write("Enter your name: "); // Prompt user for input
            string name = Console.ReadLine();   // Read input from console

            Console.WriteLine($"Hello, {name}! Welcome to .NET."); // Print greeting
        }
    }
}
