using System;

namespace _2._Knights_of_Honor_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var allNames = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> sirInserter = PrintNames;
            sirInserter(allNames);
        }
        public static void PrintNames(string[] names)
        {
            foreach (var name in names)
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
