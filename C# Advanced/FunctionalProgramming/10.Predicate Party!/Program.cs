using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party__EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var partyPeople = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = string.Empty;
            Func<string, List<string>, int, List<string>> lenghtComparer = RemoveOrDoubleByLenght;
            Func<string, List<string>, string, List<string>> endsWithComparer = RemoveOrDoubleByEnd;
            Func<string, List<string>, string, List<string>> startsWithComparer = RemoveOrDoubleByStart;
            while ((command = Console.ReadLine()) != "Party!")
            {
                var commandInList = command.Split();
                string doubleOrRemove = commandInList[0];
                if (commandInList[1] == "Length")
                {
                    int length = int.Parse(commandInList[2]);
                    partyPeople = lenghtComparer(doubleOrRemove, partyPeople, length);
                }
                else if (commandInList[1] == "EndsWith" )
                {
                    string endsWith = commandInList[2];
                    partyPeople = endsWithComparer(doubleOrRemove, partyPeople, endsWith);
                }
                else if (commandInList[1] == "StartsWith")
                {
                    string startsWith = commandInList[2];
                    partyPeople = startsWithComparer(doubleOrRemove, partyPeople, startsWith);
                }
            }
            if (partyPeople.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", partyPeople)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        public static List<string> RemoveOrDoubleByLenght(string doubleOrRemove, List<string> names, int length)
        {
            var newPeopleList = new List<string>();
            newPeopleList.AddRange(names);
            int counter = 0;
            if (doubleOrRemove == "Double")
            {
                foreach (var name in names)
                {
                    if (name.Length == length)
                    {
                        newPeopleList.Insert(counter, name);
                    }
                    counter++;
                }
            }
            else if (doubleOrRemove == "Remove")
            {
                foreach (var name in names)
                {
                    if (name.Length == length)
                    {
                        newPeopleList.Remove(name);
                    }
                }
            }
            return newPeopleList;
        }
        public static List<string> RemoveOrDoubleByEnd(string doubleOrRemove, List<string> names, string endsWith)
        {
            var newPeopleList = new List<string>();
            newPeopleList.AddRange(names);
            int counter = 0;
            if (doubleOrRemove == "Double")
            {
                foreach (var name in names)
                {
                    if (name.EndsWith(endsWith))
                    {
                        newPeopleList.Insert(counter, name);
                    }
                    counter++;
                }
            }
            else if (doubleOrRemove == "Remove")
            {
                foreach (var name in names)
                {
                    if (name.EndsWith(endsWith))
                    {
                        newPeopleList.Remove(name);
                    }
                }
            }
            return newPeopleList;
        }
        public static List<string> RemoveOrDoubleByStart(string doubleOrRemove, List<string> names, string startsWith)
        {
            var newPeopleList = new List<string>();
            newPeopleList.AddRange(names);
            int counter = 0;
            if (doubleOrRemove == "Double")
            {
                foreach (var name in names)
                {
                    if (name.StartsWith(startsWith))
                    {
                        newPeopleList.Insert(counter, name);
                    }
                    counter++;
                }
            }
            else if (doubleOrRemove == "Remove")
            {
                foreach (var name in names)
                {
                    if (name.StartsWith(startsWith))
                    {
                        newPeopleList.Remove(name);
                    }
                }
            }
            return newPeopleList;
        }
    }
}
