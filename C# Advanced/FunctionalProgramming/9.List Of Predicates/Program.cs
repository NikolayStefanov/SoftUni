using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._List_of_Predicates_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var sequenceOfDividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var rightNumbers = new List<int>();
            Func<List<int>, int, bool> isDivide = IsDivided;
            for (int i = 1; i <= number; i++)
            {
                if (isDivide(sequenceOfDividers, i))
                {
                    rightNumbers.Add(i);
                }
            }
            Console.WriteLine(string.Join(' ', rightNumbers));

        }
        public static bool IsDivided(List<int> numbers, int currNum)
        {
            foreach (var num in numbers)
            {
                if (currNum % num != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
