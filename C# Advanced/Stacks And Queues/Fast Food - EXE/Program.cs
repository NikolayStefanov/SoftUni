using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food__REAL_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodForDay = int.Parse(Console.ReadLine());
            var inputOrders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>(inputOrders);
            Console.WriteLine(queue.Max());
            while (queue.Any())
            {
                if (foodForDay - queue.Peek() >= 0)
                {
                    foodForDay -= queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: " + string.Join(" ", queue));
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
