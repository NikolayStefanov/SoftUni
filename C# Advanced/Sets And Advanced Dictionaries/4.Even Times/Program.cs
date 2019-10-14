using System;
using System.Collections.Generic;

namespace _4._Even_Times__EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<int, int>();
            var finalSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int inputNum = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(inputNum))
                {
                    dict[inputNum] = 0;
                }
                dict[inputNum]++;
            }
            foreach (var count in dict)
            {
                if (count.Value % 2 == 0)
                {
                    finalSet.Add(count.Key);
                }
            }
            foreach (var finEle in finalSet)
            {
                Console.WriteLine(finEle);
            }

        }
    }
}
