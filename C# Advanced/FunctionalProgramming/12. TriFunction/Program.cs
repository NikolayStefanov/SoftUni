using System;
using System.Linq;

namespace _12._TriFunction_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isLargerOrEqual = (word, criteria) => word.Sum(x => x) >= criteria;
            int targerSum = int.Parse(Console.ReadLine());
            string[] namesInput = Console.ReadLine().Split();
            Func<string[], Func<string, int, bool>, string> myFunc = (names, isLarger) => names.FirstOrDefault(x => isLarger(x, targerSum));
            string targetName = myFunc(namesInput, isLargerOrEqual);
            Console.WriteLine(targetName);
        }
    }
}
