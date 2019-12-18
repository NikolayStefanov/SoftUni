using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var malesSequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var femalesSequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var males = new Stack<int>(malesSequence);
            var females = new Queue<int>(femalesSequence);
            var matchCount = 0;
            while (males.Any() &&  females.Any())
            {
                var currFemale = females.Peek();
                if (currFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }
                if (currFemale % 25 == 0)
                {
                    females.Dequeue();
                    if (females.Any())
                    {
                        females.Dequeue();
                        continue;
                    }
                }
                var currMale = males.Peek();
                if (currMale <= 0)
                {
                    males.Pop();
                    continue;
                }
                if (currMale % 25 == 0)
                {
                    males.Pop();
                    if (males.Any())
                    {
                        males.Pop();
                        continue;
                    }                    
                }
                if (currMale == currFemale)
                {
                    males.Pop();
                    females.Dequeue();
                    matchCount++;
                }
                else
                {
                    females.Dequeue();
                    currMale -= 2;
                    males.Pop();
                    males.Push(currMale);
                }
                
            }

            Console.WriteLine($"Matches: {matchCount}");
            if (males.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine($"Males left: none");
            }
            if (females.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
