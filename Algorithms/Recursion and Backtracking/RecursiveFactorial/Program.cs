using System;

namespace RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFactorial(inputNumber));
        }

        private static long GetFactorial(int inputNumber)
        {
            if (inputNumber == 0)
            {
                return 1;
            }
            var result = inputNumber * GetFactorial(inputNumber-1);
            return result;
        }
    }
}
