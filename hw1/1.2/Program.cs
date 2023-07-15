using System;
using System.Collections.Generic;
using System.Text;

namespace _1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the string:");
            string str = Console.ReadLine();
            (string, int) result = BWT.Transform(str);
            Console.WriteLine("bwt: " + str + " -> " + result);
            Console.WriteLine("reverseBwt: " + result + " -> " + BWT.Detransform(result));
            Console.WriteLine(BWT.Detransform(result) == str ? "ok" : "failed");
        }
    }
}
