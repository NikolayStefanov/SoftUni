using System;
using System.Collections.Generic;

namespace _3._Periodic_Table_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var hashSet = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var inputElements = Console.ReadLine().Split();
                for (int j = 0; j < inputElements.Length; j++)
                {
                    hashSet.Add(inputElements[j]);
                }
            }
            Console.WriteLine(string.Join(" ", hashSet));
        }
    }
}
