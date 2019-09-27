using System;
using System.Linq;

namespace _1._Diagonal_Difference_REAL_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquare = int.Parse(Console.ReadLine());
            var theMatrix = new int[sizeOfSquare, sizeOfSquare];
            int sumOfFirstDiagonal = 0;
            int sumOfSecondDiagonal = 0;
            for (int row = 0; row < sizeOfSquare; row++)
            {
                var inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < sizeOfSquare; col++)
                {
                    theMatrix[row, col] = inputNums[col];
                    if (row == col)
                    {
                        sumOfFirstDiagonal += theMatrix[row, col];
                    }
                }
            }
            int count = 1;
            for (int row = 0; row < theMatrix.GetLength(0); row++)
            {
                for (int col = theMatrix.GetLength(1) - 1; col >= 0; col--)
                {
                    if (col == theMatrix.GetLength(1) - count)
                    {
                        sumOfSecondDiagonal += theMatrix[row, col];
                    }
                }
                count++;
            }
            int result = Math.Abs(sumOfFirstDiagonal - sumOfSecondDiagonal);
            Console.WriteLine(result);
        }
    }
}
