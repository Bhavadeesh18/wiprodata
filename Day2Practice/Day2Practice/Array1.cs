﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication
{
    internal class ArrayExample
    {
        public void Show()
        {
            int[] a = new int[] { 12, 5, 23, 66, 22 };
            //for(int i = 0; i < a.Length; i++)
            //{
            //    Console.WriteLine(a[i]);
            //}
            foreach (int i in a)
            {
                Console.WriteLine(i);
            }
        }
        static void Main()
        {
            ArrayExample example = new ArrayExample();
            example.Show();
        }
    }
}