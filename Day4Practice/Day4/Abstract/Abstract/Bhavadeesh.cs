using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample1
{
    internal class Bhavadeesh : Training
    {
        public override void Email()
        {
            Console.WriteLine("Hi My Email is nbr@gmail.com");
        }

        public override void Name()
        {
            Console.WriteLine("Hi I am Bhavadeesh...");
        }
    }
}