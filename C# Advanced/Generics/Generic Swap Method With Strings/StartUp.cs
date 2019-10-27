using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var list = new List<int>();
            for (int i = 0; i < lines; i++)
            {
                var input = int.Parse(Console.ReadLine());
                list.Add(input);
            }
            var theSwapper = new Swapper<int>(list);
            var theIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            theSwapper.SwapIndexes(theIndexes[0], theIndexes[1]);
            var finalList = theSwapper.TheList.ToArray();
            foreach (var item in finalList)
            {
                var type = item.GetType();
                Console.WriteLine($"{type}: {item}");
            }


        }
    }
}
