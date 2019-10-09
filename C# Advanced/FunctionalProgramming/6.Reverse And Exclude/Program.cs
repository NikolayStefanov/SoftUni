using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude_ЕXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int divisionNum = int.Parse(Console.ReadLine());
            var newOrder = numbers.Reverse().Where(x=> x % divisionNum != 0);
            Console.WriteLine(string.Join(" ", newOrder));
        }
    }
}
