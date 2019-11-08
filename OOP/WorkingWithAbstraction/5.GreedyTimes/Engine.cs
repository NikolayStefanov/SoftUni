using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Engine
    {
        public void Run()
        {
            long input = long.Parse(Console.ReadLine());
            string[] treasor = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag(input);

            for (int i = 0; i < treasor.Length; i += 2)
            {
                string name = treasor[i];
                long count = long.Parse(treasor[i + 1]);

                string whatIsTheTreasure = string.Empty;

                if (name.Length == 3)
                {
                    whatIsTheTreasure = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    whatIsTheTreasure = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    whatIsTheTreasure = "Gold";
                }

                if (whatIsTheTreasure == "")
                {
                    continue;
                }

                switch (whatIsTheTreasure)
                {
                    case "Gem":
                        var currGem = new Gem(name, count);
                        bag.AddGems(currGem);
                        break;
                    case "Cash":
                        var currCash = new Cash(name, count);
                        bag.AddCash(currCash);
                        break;
                    case "Gold":
                        bag.AddGold(count);
                        break;
                }
            }
            Console.WriteLine(bag);
        }
    }
}
