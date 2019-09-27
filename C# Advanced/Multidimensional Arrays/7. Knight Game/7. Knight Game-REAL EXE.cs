using System;

namespace _8._Knight_Game_REAL_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = int.Parse(Console.ReadLine());
            var matrix = new char[square, square];
            for (int row = 0; row < square; row++)
            {
                var fillUpTheMatrix = Console.ReadLine();
                var fillUp = fillUpTheMatrix.ToCharArray();
                for (int col = 0; col < square; col++)
                {
                    matrix[row, col] = fillUp[col];
                }
            }
            int currentKnightAttacks = 0;
            int mostAttacksRow = -1;
            int mostAttacksCol = -1;
            int removedKnights = 0;
            int maxAttacks = 0;

            while (true)
            {
                maxAttacks = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        currentKnightAttacks = 0;
                        if (matrix[row, col] == 'K')
                        {
                            if (IsInside(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                            {
                                currentKnightAttacks++;
                            }
                            if (IsInside(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                            {
                                currentKnightAttacks++;
                            }
                            if (IsInside(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                            {
                                currentKnightAttacks++;
                            }
                            if (IsInside(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                            {
                                currentKnightAttacks++;
                            }
                            if (IsInside(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                            {
                                currentKnightAttacks++;
                            }
                            if (IsInside(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                            {
                                currentKnightAttacks++;
                            }
                            if (IsInside(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                            {
                                currentKnightAttacks++;
                            }
                            if (IsInside(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                            {
                                currentKnightAttacks++;
                            }
                        }
                        if (currentKnightAttacks > maxAttacks)
                        {
                            maxAttacks = currentKnightAttacks;
                            mostAttacksRow = row;
                            mostAttacksCol = col;
                        }
                    }               
                }
                if (maxAttacks > 0)
                {
                    matrix[mostAttacksRow, mostAttacksCol] = '0';
                    removedKnights++;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }

            }


        }
        static bool IsInside(char[,] matrix, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < matrix.GetLength(0)
                    && targetCol >= 0 && targetCol < matrix.GetLength(1);
        }
    }
}
