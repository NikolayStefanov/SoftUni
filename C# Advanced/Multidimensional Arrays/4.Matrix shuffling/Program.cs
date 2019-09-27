using System;
using System.Linq;

namespace _4._Matrix_shuffling_REAL_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new string[dimentions[0], dimentions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var fillUpTheMatrix = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = fillUpTheMatrix[col];
                }
            }
            var command = string.Empty;
            while ((command= Console.ReadLine()) != "END")
            {
                var commandInList = command.Split().ToArray();
                if (commandInList[0] == "swap" && commandInList.Length == 5
                    && int.Parse(commandInList[1]) >= 0 && int.Parse(commandInList[1]) < matrix.GetLength(0)
                    && int.Parse(commandInList[3]) >= 0 && int.Parse(commandInList[3]) < matrix.GetLength(0)
                    && int.Parse(commandInList[2]) >= 0 && int.Parse(commandInList[2]) < matrix.GetLength(1)
                    && int.Parse(commandInList[4]) >= 0 && int.Parse(commandInList[4]) < matrix.GetLength(1))
                {
                    int row1 = int.Parse(commandInList[1]);
                    int row2 = int.Parse(commandInList[3]);
                    int col1 = int.Parse(commandInList[2]);
                    int col2 = int.Parse(commandInList[4]);

                    var swapValue = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = swapValue;
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row,col] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
