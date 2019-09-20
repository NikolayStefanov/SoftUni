using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations__EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var NSX = Console.ReadLine().Split().Select(int.Parse).ToList();
            int numbersToEnqueue = NSX[0];
            int numbersToDequeue = NSX[1];
            int searchingNumber = NSX[2];

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var theQueue = new Queue<int>();
            foreach (var number in numbers)
            {
                theQueue.Enqueue(number);
            }
            if (numbersToDequeue >= theQueue.Count)
            {
                theQueue.Clear();
                Console.WriteLine(0);
                return;
            }
            for (int i = 0; i < numbersToDequeue; i++)
            {
                theQueue.Dequeue();
            }
            int smallestNum = int.MaxValue;
            if (theQueue.Contains(searchingNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (var item in theQueue)
                {
                    if (item < smallestNum)
                    {
                        smallestNum = item;
                    }
                }
                Console.WriteLine(smallestNum);
            }

        }
    }
}
