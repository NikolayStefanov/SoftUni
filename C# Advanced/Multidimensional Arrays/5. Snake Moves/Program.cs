using System;
using System.Linq;

namespace _5._Snake_Moves_REAL_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var recSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var theString = Console.ReadLine();
            var matrix = new char[recSize[0], recSize[1]];
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (col == theString.Length)
                        {
                            counter = 0;
                        }
                        if (counter == theString.Length)
                        {
                            counter = 0;
                        }
                        matrix[row, col] = theString[counter];
                        counter++;
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (counter == theString.Length)
                        {
                            counter = 0;
                        }
                        matrix[row, col] = theString[counter];
                        counter++;
                    }
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    Console.Write(matrix[row,i]);
                }
                Console.WriteLine();
            }
        }
    }
}
