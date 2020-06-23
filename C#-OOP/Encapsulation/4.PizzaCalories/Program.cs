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
                    if (product.ToLower() == "pizza")
                    {
                        var pizzaName = commandInList[1];
                        thePizza = new Pizza(pizzaName);
                    }
                    else if (product.ToLower() == "dough")
                    {
                        var type = commandInList[1];
                        var tehnique = commandInList[2];
                        var grams = int.Parse(commandInList[3]);
                        var dough = new Dough(type, tehnique, grams);
                        thePizza.Dough = dough;
                    }
                    else if (product.ToLower() == "topping")
                    {
                        var type = commandInList[1];
                        var grams = int.Parse(commandInList[2]);
                        var topping = new Topping(type, grams);
                        thePizza.AddTopping(topping);
                    }
                }
                Console.WriteLine($"{thePizza.Name} - {thePizza.GetTotalCalories():F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
