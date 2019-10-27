using System;
using System.Collections.Generic;

namespace _5.GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var currList = new List<double>();
            for (int i = 0; i < lines; i++)
            {
                var input =double.Parse(Console.ReadLine());
                currList.Add(input);
            }
            var theElement =double.Parse(Console.ReadLine());
            var compare = new Comparer<double>(currList, theElement);
            Console.WriteLine(compare.LargerElementsByComparedElement());
        }
    }
}
