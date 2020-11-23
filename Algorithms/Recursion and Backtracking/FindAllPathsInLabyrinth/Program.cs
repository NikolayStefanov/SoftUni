using System;
using System.Collections.Generic;

namespace FindAllPathsInLabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var labyrinth = new char[rows, cols];
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    labyrinth[row, col] = input[col];
                }
            }
            var directions = new List<char>();
            FindAllPaths(labyrinth, 0, 0, directions, '\0');
        }

        private static void FindAllPaths(char[,] labyrinth, int row, int col, List<char> directions, char direction)
        {
            if (IsOutside(labyrinth, row, col) || IsAWall(labyrinth, row, col) || IsVisited(labyrinth, row, col))
            {
                return;
            }

            directions.Add(direction);

            if (IsSolution(labyrinth, row, col))
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }
            labyrinth[row, col] = 'v';

            FindAllPaths(labyrinth, row - 1, col, directions, 'U');
            FindAllPaths(labyrinth, row +1, col, directions,  'D');
            FindAllPaths(labyrinth, row, col - 1, directions, 'L');
            FindAllPaths(labyrinth, row, col + 1, directions, 'R');

            directions.RemoveAt(directions.Count-1);
            labyrinth[row, col] = '-';
        }

        private static bool IsSolution(char[,] labyrinth, int row, int col)
        {
            return labyrinth[row, col] == 'e';
        }

        private static bool IsVisited(char[,] labyrinth, int row, int col)
        {
            return labyrinth[row, col] == 'v';
        }

        private static bool IsAWall(char[,] labyrinth, int row, int col)
        {
            return labyrinth[row, col] == '*';
        }

        private static bool IsOutside(char[,] labyrinth, int row, int col)
        {
            return row < 0 ||
                row >= labyrinth.GetLength(0) ||
                col < 0 ||
                col >= labyrinth.GetLength(1);
        }
    }
}
