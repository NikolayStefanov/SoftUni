using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations__EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbersNSX = Console.ReadLine().Split().Select(int.Parse).ToList();
            int countInNumbers = inputNumbersNSX[0];
            int countToPop = inputNumbersNSX[1];
            int theElement = inputNumbersNSX[2];
            if (countInNumbers <= 0)
            {
                Console.WriteLine(0);
                return;
            }
            var theNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> theStack = new Stack<int>(theNumbers);

            if (theStack.Count > countToPop)
            {
                for (int i = 0; i < countToPop; i++)
                {
                    theStack.Pop();
                }
            }
            else
            {
                theStack.Clear();
                Console.WriteLine("0");
                return;
            }

            int theSmallestNum = int.MaxValue;

            if (theStack.Contains(theElement))
            {
                Console.WriteLine("true");
            }
            else
            {

                foreach (var num in theStack)
                {
                    if (num < theSmallestNum)
                    {
                        theSmallestNum = num;
                    }
                }
                Console.WriteLine(theSmallestNum);

            }
        }
    }
}
