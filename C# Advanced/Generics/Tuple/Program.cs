using System;
using System.Linq;

namespace _7.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nameAndAdressInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var theName = nameAndAdressInput[0] + " " + nameAndAdressInput[1];
            var theAdress = string.Empty;
            for (int i = 2; i < nameAndAdressInput.Length; i++)
            {
                theAdress += nameAndAdressInput[i] + " ";
            }
            var nameAndAdress = new Tuple<string, string>(theName, theAdress);

            var nameAndBeerInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var beerName = nameAndBeerInput[0];
            var beerLiters = int.Parse(nameAndBeerInput[1]);
            var nameAndBeer = new Tuple<string, int>(beerName, beerLiters);

            var integerAndDoubleInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            var integerAndDouble = new Tuple<double, double>(integerAndDoubleInput[0], integerAndDoubleInput[1]);

            Console.WriteLine($"{nameAndAdress.Item1} -> {nameAndAdress.Item2}");
            Console.WriteLine($"{nameAndBeer.Item1} -> {nameAndBeer.Item2}");
            Console.WriteLine($"{integerAndDouble.Item1} -> {integerAndDouble.Item2}");
        }
    }
}
