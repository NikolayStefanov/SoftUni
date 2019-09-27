using System;
using System.Linq;

namespace _3._Maximal_Sum___REAL_exe
{
    class Program
    {
        static void Main(string[] args)
        {
            var recSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[recSize[0], recSize[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var fillUpTheMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = fillUpTheMatrix[col];
                }
            }
            var maxSumRow = -1;
            var maxSumCol = -1;
            var size = 3;
            var maxSum = int.MinValue;
            for (int row = 0; row <= matrix.GetLength(0) - size; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - size; col++)
                {
                    var currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                                + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                                + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = maxSumRow; row <= maxSumRow + 2; row++)
            {
                for (int col = maxSumCol; col <= maxSumCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
