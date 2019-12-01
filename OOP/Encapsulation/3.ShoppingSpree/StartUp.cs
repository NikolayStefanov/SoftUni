using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main()
        {
            try
            {
                string[] peopleArray = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                List<Person> people = new List<Person>();


                for (int i = 0; i < peopleArray.Length; i++)
                {
                    string[] personData = peopleArray[i].Split('=');
                    string name = personData[0];
                    decimal money = decimal.Parse(personData[1]);

                    Person person = new Person(name, money);
                    people.Add(person);
                }

                List<Product> products = new List<Product>();

                string[] productsArray = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productsArray.Length; i++)
                {
                    string[] productData = productsArray[i].Split('=');
                    string name = productData[0];
                    decimal cost = decimal.Parse(productData[1]);

                    Product product = new Product(name, cost);
                    products.Add(product);
                }

                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] purchaseData = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string personName = purchaseData[0];
                    string productName = purchaseData[1];

                    Person neededPerson = people.FirstOrDefault(x => x.Name == personName);
                    Product neededProduct = products.FirstOrDefault(x => x.Name == productName);

                    if (neededPerson != null && neededProduct != null)
                    {
                        if (neededPerson.Money >= neededProduct.Cost)
                        {
                            neededPerson.Money -= neededProduct.Cost;
                            neededPerson.Add(neededProduct.Name);
                            Console.WriteLine($"{neededPerson.Name} bought {neededProduct.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"{neededPerson.Name} can't afford {neededProduct.Name}");
                        }
                    }
                    command = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    if (person.Products.Count > 0)
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}