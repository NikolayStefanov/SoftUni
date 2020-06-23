using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Food_Shortage
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var people = new List<IBuyer>();
            for (int i = 0; i < numberOfPeople; i++)
            {
                var inputPeople = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (inputPeople.Length == 3)
                {
                    var rebelName = inputPeople[0];
                    var rebelAge = int.Parse(inputPeople[1]);
                    var rebelGroup = inputPeople[2];
                    var currRebel = new Rebel(rebelName, rebelAge, rebelGroup);
                    people.Add(currRebel);
                }
                else if (inputPeople.Length == 4)
                {
                    var citizenName = inputPeople[0];
                    var citizenAge = int.Parse(inputPeople[1]);
                    var citizenID = inputPeople[2];
                    var citizenBirthDate = inputPeople[3];
                    var currCitizen = new Citizen(citizenName, citizenAge, citizenID, citizenBirthDate);
                    people.Add(currCitizen);
                }
            }
            var foodBuyers = Console.ReadLine();
            var totalFood = 0;
            while (foodBuyers != "End")
            {
                foreach (var person in people.Where(p=>p.Name== foodBuyers))
                {
                    person.BuyFood();
                }
                foodBuyers = Console.ReadLine();
            }
            foreach (var person in people)
            {
                totalFood += person.Food;
            }
            Console.WriteLine(totalFood);
        }
    }
}
