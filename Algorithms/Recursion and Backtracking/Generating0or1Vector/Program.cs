using System;

namespace Generating0or1Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());

            var vectorArray = new int[inputNumber];
            GenerateVector(vectorArray, 0);
        }

        private static void GenerateVector(int[] vectorArray, int index)
        {
            if (index == vectorArray.Length)
            {
                Console.WriteLine(string.Join('\0', vectorArray));
                return;
            }

            for (int num = 0; num <= 1; num++)
            {
                vectorArray[index] = num;
                GenerateVector(vectorArray, index+1);
            }
        }
    }
}
