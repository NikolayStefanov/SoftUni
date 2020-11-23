using System;

namespace RecursiveDrowing
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());

            RecursiveDrowing(inputNumber);
        }

        private static void RecursiveDrowing(int inputNumber)
        {
            if (inputNumber <= 0)
            {
                return;
            }
            Console.WriteLine(new string('*', inputNumber));
            RecursiveDrowing(inputNumber-1);
            Console.WriteLine(new string('#', inputNumber));
        }
    }
}
