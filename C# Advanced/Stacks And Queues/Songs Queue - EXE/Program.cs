using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstSongs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var theQueue = new Queue<string>(firstSongs);
            while (theQueue.Any())
            {
                var command = Console.ReadLine();
                if (command.StartsWith("Add "))
                {
                    var currSong = command.Substring(4, command.Length - 4);
                    if (!theQueue.Contains(currSong))
                    {
                        theQueue.Enqueue(currSong);
                    }
                    else
                    {
                        Console.WriteLine($"{currSong} is already contained!");
                    }
                }
                else if (command == "Play")
                {
                    if (theQueue.Any())
                    {
                        theQueue.Dequeue();
                    }
                }
                else if (command == "Show")
                {
                    if (theQueue.Any())
                    {
                        Console.WriteLine(string.Join(", ", theQueue ));
                    }
                }
                if (!theQueue.Any())
                {
                    Console.WriteLine("No more songs!");
                    return;
                }
            }

        }
    }
}
