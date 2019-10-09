using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr11.__Party_Reserv_Filter_Module
{
    class Program
    {
        static void Main()
        {
            var partyPeople = Console.ReadLine().Split().ToList();
            var filters = new List<string>();
            AddFilters(filters);
            ApplyFilters(filters, partyPeople);
            PrintList(partyPeople);
        }

        static void AddFilters(List<string> filters)
        {
            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                var commands = input.Split(";");
                var action = commands[0];
                var filter = commands[1];
                var value = commands[2];
                if (action == "Add filter")
                {
                    filters.Add(CreatePredicateString(filter, value));
                }
                else if (action == "Remove filter")
                {
                    var searchFilter = CreatePredicateString(filter, value);
                    filters.Remove(searchFilter);
                }

            }
        }

        static void ApplyFilters(List<string> filters, List<string> list)
        {
            foreach (var filter in filters)
            {
                var predicate = CreatePredicate(filter);
                list.RemoveAll(n => predicate(n));
            }
        }

        static void PrintList(List<string> list)
        {
            Console.WriteLine(string.Join(" ", list));
        }

        static string CreatePredicateString(string filter, string value)
        {
            return $"{filter};{value}";
        }

        static Func<string, bool> CreatePredicate(string filter)
        {
            var commands = filter.Split(";");
            var value = commands[1];
            switch (commands[0])
            {
                case "Starts with": return (n => n.StartsWith(value));
                case "Ends with": return (n => n.EndsWith(value));
                case "Length": return (n => n.Length == value.Length);
                case "Contains": return (n => n.Contains(value));
            }
            return null;
        }
    }
}