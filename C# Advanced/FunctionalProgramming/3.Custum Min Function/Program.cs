using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Custom_Min_Function_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            HashSet<int> numbers = new HashSet<int>(inputNums);

            Func<HashSet<int>, int> minNumber = MinNumber;
            Console.WriteLine(minNumber(numbers));
        }
        public static int MinNumber(HashSet<int> numbers)
        {
            var minNum = int.MaxValue;
            foreach (var num in numbers)
            {
                if (num < minNum)
                {
                    minNum = num;
                }
            }
            return minNum;
        }
    }
}
