using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var squareSize = int.Parse(Console.ReadLine());
            var wordInCharArr = word.ToCharArray();
            var playerRow = -1;
            var playerCol = -1;
            var resultWord = new List<char>(wordInCharArr);
            var matrix = new char[squareSize, squareSize];
            for (int row = 0; row < squareSize; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < squareSize; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            var command = string.Empty;
            var targetRow = -1;
            var targetCol = -1;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up")
                {
                    targetRow = playerRow - 1;
                    targetCol = playerCol;
                    if (IsInside(matrix, targetRow, targetCol))
                    {
                        var currChar = matrix[targetRow, targetCol];
                        if (char.IsLetter(currChar))
                        {
                            resultWord.Add(currChar);
                            matrix[playerRow, playerCol] = '-';
                            matrix[targetRow, targetCol] = 'P';
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[targetRow, targetCol] = 'P';
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                    }
                    else
                    {
                        if (resultWord.Count > 0)
                        {
                            resultWord.RemoveAt(resultWord.Count - 1);
                        }
                    }
                }
                if (command == "down")
                {
                    targetRow = playerRow + 1;
                    targetCol = playerCol;
                    if (IsInside(matrix, targetRow, targetCol))
                    {
                        var currChar = matrix[targetRow, targetCol];
                        if (char.IsLetter(currChar))
                        {
                            resultWord.Add(currChar);
                            matrix[playerRow, playerCol] = '-';
                            matrix[targetRow, targetCol] = 'P';
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[targetRow, targetCol] = 'P';
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                    }
                    else
                    {
                        if (resultWord.Count > 0)
                        {
                            resultWord.RemoveAt(resultWord.Count - 1);
                        }
                    }
                }
                if (command == "left")
                {
                    targetRow = playerRow;
                    targetCol = playerCol - 1;
                    if (IsInside(matrix, targetRow, targetCol))
                    {
                        var currChar = matrix[targetRow, targetCol];
                        if (char.IsLetter(currChar))
                        {
                            resultWord.Add(currChar);
                            matrix[playerRow, playerCol] = '-';
                            matrix[targetRow, targetCol] = 'P';
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[targetRow, targetCol] = 'P';
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                    }
                    else
                    {
                        if (resultWord.Count > 0)
                        {
                            resultWord.RemoveAt(resultWord.Count - 1);
                        }
                    }
                }
                if (command == "right")
                {
                    targetRow = playerRow;
                    targetCol = playerCol + 1;
                    if (IsInside(matrix, targetRow, targetCol))
                    {
                        var currChar = matrix[targetRow, targetCol];
                        if (char.IsLetter(currChar))
                        {
                            resultWord.Add(currChar);
                            matrix[playerRow, playerCol] = '-';
                            matrix[targetRow, targetCol] = 'P';
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[targetRow, targetCol] = 'P';
                            playerRow = targetRow;
                            playerCol = targetCol;
                        }
                    }
                    else
                    {
                        if (resultWord.Count > 0)
                        {
                            resultWord.RemoveAt(resultWord.Count - 1);
                        }
                    }
                }
            }
            var finalWord = new StringBuilder();
            for (int i = 0; i < resultWord.Count; i++)
            {
                finalWord.Append(resultWord[i]);
            }
            Console.WriteLine(finalWord.ToString());
            PrintTheMatrix(matrix);
        }

        private static void PrintTheMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(char[,] matrix, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < matrix.GetLength(0) && targetCol >= 0 && targetCol < matrix.GetLength(1);
        }
    }
}
