using System;
using System.Collections.Generic;

namespace _6._Wardrobe_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();
            int linesOfInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesOfInput; i++)
            {
                var input = Console.ReadLine().Split(" -> ");
                string currColor = input[0];
                var listOfClothes = input[1].Split(',');
                if (!dict.ContainsKey(currColor))
                {
                    dict[currColor] = new Dictionary<string, int>();
                }
                for (int j = 0; j < listOfClothes.Length; j++)
                {
                    if (!dict[currColor].ContainsKey(listOfClothes[j]))
                    {
                        dict[currColor][listOfClothes[j]] = 0;
                    }
                    dict[currColor][listOfClothes[j]]++;
                }
            }
            var finalSearch = Console.ReadLine().Split();
            string finalColor = finalSearch[0];
            string finalCloth = finalSearch[1];

            foreach (var color in dict)
            {
                Console.WriteLine($"{color.Key} clothes:");
                if (color.Key == finalColor)
                {
                    foreach (var cloth in color.Value)
                    {
                        if (cloth.Key != finalCloth)
                        {
                            Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                        }
                        else
                        {
                            Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                        }
                    }
                }
                else
                {
                    foreach (var cloth in color.Value)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
