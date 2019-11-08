using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animalKind = string.Empty;
            List<string> animalInfo = null;
            var animals = new List<Animal>();
            while ((animalKind = Console.ReadLine()) != "Beast!")
            {
                animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                var animalName = animalInfo[0];
                var animalAge = int.Parse(animalInfo[1]);
                var animalGender = animalInfo[2];
                try
                {
                    switch (animalKind.ToLower())
                    {
                        case "cat":
                            animals.Add(new Cat(animalName, animalAge,  animalGender));
                            break;
                        case "kitten":
                            animals.Add(new Kitten(animalName, animalAge));
                            break;
                        case "tomcat":
                            animals.Add(new Tomcat(animalName, animalAge));
                            break;
                        case "dog":
                            animals.Add(new Dog(animalName, animalAge, animalGender));
                            break;
                        case "frog":
                            animals.Add(new Frog(animalName, animalAge, animalGender));
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception ageEx)
                {
                    Console.WriteLine(ageEx.Message);   
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
