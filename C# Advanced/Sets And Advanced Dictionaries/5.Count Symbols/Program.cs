using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Count_Symbols_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var theDict = new SortedDictionary<char, int>();
            string inputText = Console.ReadLine();
            for (int i = 0; i < inputText.Length; i++)
            {
                var currChar = inputText[i];
                if (!theDict.ContainsKey(currChar))
                {
                    theDict[currChar] = 0;
                }
                theDict[currChar]++;
            }

            foreach (var currSymbol in theDict)
            {
                Console.WriteLine($"{currSymbol.Key}: {currSymbol.Value} time/s");
            }
        }
    }
}
