using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];
            FillUp(matrix);
            var bombCoordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                var bombCoordinatesInList = bombCoordinates[i].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var bombRow = bombCoordinatesInList[0];
                var bombCol = bombCoordinatesInList[1];
                var bombValue = matrix[bombRow, bombCol];
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row == bombRow && col == bombCol)
                        {
                            if (matrix[bombRow, bombCol] <= 0) 
                            {
                                continue;
                            }
                            if (IsInside(matrix, row -1, col-1) && matrix[row-1, col-1] > 0)
                            {
                                matrix[row - 1, col - 1] -= bombValue;
                            }
                            if (IsInside(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                            {
                                matrix[row - 1, col] -= bombValue;
                            }
                            if (IsInside(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                            {
                                matrix[row - 1, col + 1] -= bombValue;
                            }
                            if (IsInside(matrix, row , col - 1) && matrix[row , col - 1] > 0)
                            {
                                matrix[row , col - 1] -= bombValue;
                            }
                            if (IsInside(matrix, row , col + 1) && matrix[row , col + 1] > 0)
                            {
                                matrix[row, col + 1] -= bombValue;
                            }
                            if (IsInside(matrix, row +1, col - 1) && matrix[row + 1, col - 1] > 0)
                            {
                                matrix[row + 1, col - 1] -= bombValue;
                            }
                            if (IsInside(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                            {
                                matrix[row + 1, col] -= bombValue;
                            }
                            if (IsInside(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                            {
                                matrix[row + 1, col + 1] -= bombValue;
                            }
                            matrix[row, col] = 0;
                        }
                    }
                }
            }
            var sumOfAlive = 0;
            var aliveCells = 0;
            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    sumOfAlive += cell;
                    aliveCells++;
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfAlive}");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                    && col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillUp(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRowNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRowNumbers[col];
                }
            }
        }
    }
}
