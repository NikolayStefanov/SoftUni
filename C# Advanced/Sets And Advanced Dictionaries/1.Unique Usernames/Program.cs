using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Unique_Usernames__EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                var allClothes = input[1].Split(",");
                if (!dict.ContainsKey(color))
                {
                    dict[color] = new Dictionary<string, int>();
                }
                for (int m = 0; m < allClothes.Length; m++)
                {
                    var currCloth = allClothes[m];
                    if (!dict[color].ContainsKey(currCloth))
                    {
                        dict[color][currCloth] = 0;
                    }
                    dict[color][currCloth]++;
                }
            }
            var searching = Console.ReadLine().Split();
            var searchingColor = searching[0];
            var searchingCloth = searching[1];
            foreach (var color in dict)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    if (searchingColor != color.Key || searchingCloth != cloth.Key)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                }
            }

        }
    }
}
