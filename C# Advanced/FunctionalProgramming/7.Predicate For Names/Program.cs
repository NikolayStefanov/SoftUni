using System;
using System.Linq;

namespace _7._Predicate_for_Names_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLenght = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            PrintRightNames(nameLenght, names);
        }

        private static void PrintRightNames(int nameLenght, string[] names)
        {
            foreach (var name in names.Where(x => x.Length <= nameLenght))
            {
                Console.WriteLine(name);
            }
        }
    }
}
