using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sets_of_Elements_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstandSecondSet = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < firstandSecondSet[0]; i++)
            {
                var firstInput = int.Parse(Console.ReadLine());
                firstSet.Add(firstInput);
            }
            for (int i = 0; i < firstandSecondSet[1]; i++)
            {
                var secondInput = int.Parse(Console.ReadLine());
                secondSet.Add(secondInput);
            }
            var listOfSameNums = new List<int>();
            foreach (var num in firstSet)
            {
                foreach (var secNum in secondSet)
                {
                    if (num == secNum)
                    {
                        listOfSameNums.Add(num);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", listOfSameNums));    
        }
    }
}
