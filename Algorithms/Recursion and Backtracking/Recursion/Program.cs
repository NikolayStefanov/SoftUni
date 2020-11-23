using System;
using System.Linq;

namespace RecursiveArraySum
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var firstIndex = 0;
            Console.WriteLine(RecursiveSum(inputArray, firstIndex));
        }

        private static int RecursiveSum(int[] inputArray, int firstIndex)
        {
            if (firstIndex == inputArray.Length-1)
            {
                return inputArray[firstIndex];
            }
           
            return inputArray[firstIndex] + RecursiveSum(inputArray, firstIndex+1);
        }
    }
}
