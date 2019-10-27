using System;
using System.Collections.Generic;

namespace _1._Generic_Box_of_String
{
    public class StartUp  
    {
        static void Main(string[] args)
        {
            var theBoxList = new List<Box<int>>();
            var inputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputLines; i++)
            {
                var input =int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                theBoxList.Add(box);
            }
            foreach (var box in theBoxList)
            {
                Console.WriteLine(box.ToString());
            }

        }
    }
}
