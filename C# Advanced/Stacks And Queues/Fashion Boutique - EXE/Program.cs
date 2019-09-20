using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique_REAL_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothesValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();          
            int countOfRacks = 1;
            int capacity = int.Parse(Console.ReadLine());
            var stack = new Stack<int>(clothesValues);
            int currRack = 0;

            while (stack.Any())
            {
                var currCloth = stack.Peek();
                currRack += currCloth;
                if (currRack > capacity)
                {
                    countOfRacks++;
                    currRack = 0;
                }
                else if (currRack == capacity)
                {
                    stack.Pop();
                    if (stack.Any())
                    {
                        countOfRacks++;
                        currRack = 0;
                    }
                }
                else
                {
                    stack.Pop();
                }
            }
            Console.WriteLine(countOfRacks);
        }
    }
}
