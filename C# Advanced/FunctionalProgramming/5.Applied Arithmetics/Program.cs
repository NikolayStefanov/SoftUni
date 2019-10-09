using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Func<string, List<int>, List<int>> simpleOperator = Operations;
            var com = string.Empty;
            while ((com = Console.ReadLine()) != "end")
            {
                if (com == "print")
                {
                    PrintTheList(numbers);
                }
                else
                {
                    simpleOperator(com, numbers);
                }
            }

        }

        private static void PrintTheList(List<int> numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }

        public static List<int> Operations(string command, List<int> numbers)
        {
            switch (command)
            {
                case "add":
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] += 1;
                    }
                    break;
                case "multiply":
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] *= 2;
                    }
                    break;
                case "subtract":
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] -= 1;
                    }
                    break;
            }
            return numbers;
        }
    }
}
