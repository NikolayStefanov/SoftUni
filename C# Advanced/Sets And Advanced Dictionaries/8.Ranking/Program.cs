using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._The_V_Logger_EXE
{
    class Vloger
    {
        public List<string> Followers { get; set; } = new List<string>();
        public int Following { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var vlogersDict = new Dictionary<string, Vloger>();
            string command = string.Empty;
            while ((command =Console.ReadLine()) != "Statistics")
            {
                var commandInList = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command.Contains("joined The V-Logger") && commandInList[1] == "joined")
                {
                    var vloggerName = commandInList[0];
                    if (!vlogersDict.ContainsKey(vloggerName))
                    {
                        vlogersDict[vloggerName] = new Vloger();
                    }
                }
                else if (commandInList[1] == "followed" && commandInList.Length == 3)
                {
                    var followedVlogger = commandInList[2];
                    var followingVlogger = commandInList[0];
                    if (followedVlogger != followingVlogger && vlogersDict.ContainsKey(followedVlogger) && vlogersDict.ContainsKey(followingVlogger))
                    {
                        if (!vlogersDict[followedVlogger].Followers.Contains(followingVlogger))
                        {
                            vlogersDict[followedVlogger].Followers.Add(followingVlogger);
                            vlogersDict[followingVlogger].Following--;
                        }
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vlogersDict.Count} vloggers in its logs.");
            var counter = 0;
            foreach (var vloger in vlogersDict.OrderByDescending(x => x.Value.Followers.Count).ThenByDescending(x => x.Value.Following))
            {
                counter++;
                Console.WriteLine($"{counter}. {vloger.Key} : {vloger.Value.Followers.Count} followers, {Math.Abs(vloger.Value.Following)} following");
                if (counter == 1)
                {
                    foreach (var follower in vloger.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

            }

        }
    }
}
