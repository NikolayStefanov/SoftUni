using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Auto_Repair_and_Service__EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var servedCars = new Stack<string>();
            var listOfCars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var repairingCars = new Queue<string>(listOfCars);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Service" && repairingCars.Any())
                {
                    string currCar = repairingCars.Dequeue();
                    servedCars.Push(currCar);
                    Console.WriteLine($"Vehicle {currCar} got served.");
                }
                else if (command.Contains("CarInfo-"))
                {
                    var commandInList = command.Split('-').ToList();
                    if (repairingCars.Contains(commandInList[1]))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else if (servedCars.Contains(commandInList[1]))
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (command == "History")
                {
                    Console.WriteLine(string.Join(", ", servedCars));
                }
            }

            if (repairingCars.Any())
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", repairingCars)}");
            }
            if (servedCars.Any())
            {
                Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");
            }
        }
    }
}
