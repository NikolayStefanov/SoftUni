using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumbers = int.Parse(Console.ReadLine());
            var theStack = new Stack<int>();

            for (int i = 0; i < inputNumbers; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToList();
                if (input.Count == 2 && input[1] <= 109)
                {
                    theStack.Push(input[1]);
                }
                else
                {
                    int smallestNum = int.MaxValue;
                    int biggestNum = int.MinValue;
                    if (input[0] == 2 && theStack.Count > 0)
                    {
                        theStack.Pop();
                    }
                    else if (input[0] == 3)
                    {
                        foreach (var num in theStack)
                        {
                            if (num > biggestNum)
                            {
                                biggestNum = num;
                            }
                        }
                        Console.WriteLine(biggestNum);
                    }
                    else if (input[0] == 4)
                    {
                        foreach (var num in theStack)
                        {
                            if (num < smallestNum)
                            {
                                smallestNum = num;
                            }
                        }
                        Console.WriteLine(smallestNum);
                    }
                }

            }
            Console.WriteLine(string.Join(", ", theStack));
        }
    }
}
