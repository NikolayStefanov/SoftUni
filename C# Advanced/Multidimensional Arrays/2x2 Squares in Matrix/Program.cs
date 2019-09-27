using System;
using System.Linq;

namespace _2._2x2_Squares_in_Matrix___REAL_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfMatrix = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new string[sizeOfMatrix[0], sizeOfMatrix[1]];
            int squareOfSameSymbols = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var writeTheMat = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = writeTheMat[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (matrix[row,col] == matrix[row, col+1] 
                        && matrix[row, col] == matrix[row+1, col] 
                        && matrix[row, col] == matrix[row+1, col+1])
                    {
                        squareOfSameSymbols++;
                    }
                }
            }
            Console.WriteLine(squareOfSameSymbols);
        }
    }
}
