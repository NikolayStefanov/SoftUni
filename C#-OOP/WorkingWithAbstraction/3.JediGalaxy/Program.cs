using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];
            FillUpTheMatrix(matrix);
            
            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int evilRow = evil[0];
                int evilCol = evil[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (evilRow < matrix.GetLength(0) && evilCol < matrix.GetLength(1))
                    {
                        matrix[evilRow, evilCol] = 0;
                    }
                    evilRow--;
                    evilCol--;
                }

                int ivosRow = ivoS[0];
                int ivosCol = ivoS[1];

                while (ivosRow >= 0 && ivosCol < matrix.GetLength(1))
                {
                    if (ivosRow < matrix.GetLength(0) && ivosCol >= 0)
                    {
                        sum += matrix[ivosRow, ivosCol];
                    }

                    ivosCol++;
                    ivosRow--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static void FillUpTheMatrix(int[,] matrix)
        {
            int value = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }
    }
}
