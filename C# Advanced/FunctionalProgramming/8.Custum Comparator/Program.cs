using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Custom_Comparator_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], List<int>> sortedNumbers = EvenOddComparator;
            Console.WriteLine(string.Join(' ', sortedNumbers(numbers)));


        }
        public static List<int> EvenOddComparator(int[] numbers)
        {
            var sortedNums = new List<int>();
            var evenNums = new List<int>();
            var oddNums = new List<int>();
            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                {
                    evenNums.Add(num);
                }
                else
                {
                    oddNums.Add(num);
                }
            }
            evenNums.Sort();
            oddNums.Sort();
            sortedNums.AddRange(evenNums);
            sortedNums.AddRange(oddNums);

            return sortedNums;
        }
    }
}
