using System;

namespace _1._Action_Point_exe
{
    class Program
    {
        static void Main(string[] args)
        {
            var allNames = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> namesAction = PrintNames;
            namesAction(allNames);
        }

        private static void PrintNames(string[] names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
