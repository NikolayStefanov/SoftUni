using System;

namespace _4.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;
            Pizza thePizza = null;

            try
            {
                while ((command = Console.ReadLine()) != "END")
                {
                    var commandInList = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var product = commandInList[0];
                    if (product == "Pizza")
                    {
                        var pizzaName = commandInList[1];
                        thePizza = new Pizza(pizzaName);
                    }
                    else if (product == "Dough")
                    {
                        var type = commandInList[1];
                        var tehnique = commandInList[2];
                        var grams = int.Parse(commandInList[3]);
                        var dough = new Dough(type, tehnique, grams);
                        thePizza.Dough = dough;
                    }
                    else if (product == "Topping")
                    {
                        var type = commandInList[1];
                        var grams = int.Parse(commandInList[2]);
                        var topping = new Topping(type, grams);
                        thePizza.AddTopping(topping);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine(thePizza);
        }
    }
}
