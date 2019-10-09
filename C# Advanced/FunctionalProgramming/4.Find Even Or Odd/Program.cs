using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds_exe
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var evenOrOdd = Console.ReadLine().ToLower();

            Predicate<int> isEven = IsEven;
            var finalList = new List<int>();
            if (evenOrOdd == "even")
            {
                for (int i = range[0]; i <= range[1] ; i++)
                {
                    if (isEven(i))
                    {
                        finalList.Add(i);
                    }
                }
            }
            else if (evenOrOdd == "odd")
            {
                for (int i = range[0]; i <= range[1]; i++)
                {
                    if (!IsEven(i))
                    {
                        finalList.Add(i);
                    }
                }
            }
            Console.WriteLine(string.Join(' ', finalList));

        }
        private static bool IsEven(int number) => number % 2 == 0;
    }
}
