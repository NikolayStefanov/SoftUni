using _3.WildFarm.Animals;
using _3.WildFarm.Animals.Birds;
using _3.WildFarm.Animals.Mammals;
using _3.WildFarm.Food;
using System;
using System.Collections.Generic;

namespace _3.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<IAnimal>();
            var command = string.Empty;
            var counter = 0;
            var helpCounter = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    var arguments = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (counter % 2 == 0)
                    {
                        var animalType = arguments[0];
                        var animalName = arguments[1];
                        var weight = double.Parse(arguments[2]);
                        switch (animalType)
                        {
                            case "Cat":
                                var livingRegion = arguments[3];
                                var breed = arguments[4];
                                var currCat = new Cat(animalName,weight, livingRegion, breed);
                                animals.Add(currCat);
                                break;
                            case "Tiger":
                                livingRegion = arguments[3];
                                breed = arguments[4];
                                var currTiger = new Tiger(animalName, weight, livingRegion, breed);
                                animals.Add(currTiger);
                                break;
                            case "Owl":
                                var wingSize = double.Parse(arguments[3]);
                                var currOwl = new Owl(animalName, weight, wingSize);
                                animals.Add(currOwl);
                                break;
                            case "Hen":
                                wingSize = double.Parse(arguments[3]);
                                var currHen = new Hen(animalName, weight, wingSize);
                                animals.Add(currHen);
                                break;
                            case "Mouse":
                                livingRegion = arguments[3];
                                var currMouse = new Mouse(animalName, weight, livingRegion);
                                animals.Add(currMouse);
                                break;
                            case "Dog":
                                livingRegion = arguments[3];
                                var currDog = new Dog(animalName, weight, livingRegion);
                                animals.Add(currDog);
                                break;
                        }

                    }
                    else
                    {
                        var foodName = arguments[0];
                        var foodQuantity = int.Parse(arguments[1]);
                        switch (foodName)
                        {
                            case "Fruit":
                                var currFruit = new Fruit(foodQuantity);
                                Console.WriteLine(animals[animals.Count-1].AskForFood());
                                animals[animals.Count - 1].Feed(currFruit, currFruit.Quantity);                              
                                break;
                            case "Vegetable":
                                var currVege = new Vegetable(foodQuantity);
                                Console.WriteLine(animals[animals.Count-1].AskForFood());
                                animals[animals.Count - 1].Feed(currVege, currVege.Quantity);
                                break;
                            case "Meat":
                                var currMeat = new Meat(foodQuantity);
                                Console.WriteLine(animals[animals.Count-1].AskForFood());
                                animals[animals.Count - 1].Feed(currMeat, currMeat.Quantity);
                                break;
                            case "Seeds":
                                var currSeeds = new Seeds(foodQuantity);
                                Console.WriteLine(animals[animals.Count-1].AskForFood());
                                animals[animals.Count - 1].Feed(currSeeds, currSeeds.Quantity);
                                break;
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                counter++;
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
