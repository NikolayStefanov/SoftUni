using System;

namespace _1.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var busInfo = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

            var carFuel = double.Parse(carInfo[1]);
            var carConsumption = double.Parse(carInfo[2]);
            var carCapacity = double.Parse(carInfo[3]);
            var theCar = new Car(carFuel, carConsumption, carCapacity);

            var truckFuel = double.Parse(truckInfo[1]);
            var truckConsumption = double.Parse(truckInfo[2]);
            var truckCapacity = double.Parse(truckInfo[3]);
            var theTruck = new Truck(truckFuel, truckConsumption, truckCapacity);

            var busFuel = double.Parse(busInfo[1]);
            var busConsumption = double.Parse(busInfo[2]);
            var busCapacity = double.Parse(busInfo[3]);
            var theBus = new Bus(busFuel, busConsumption, busCapacity);

            var numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                var driveOrRefuel = command[0];
                var carOrTruck = command[1];
                var amout = double.Parse(command[2]);
                switch (carOrTruck)
                {
                    case "Car":
                        switch (driveOrRefuel)
                        {
                            case "Drive":
                                theCar.Drive(amout);
                                break;
                            case "Refuel":
                                theCar.Refuel(amout);
                                break;
                        }
                        break;
                    case "Truck":
                        switch (driveOrRefuel)
                        {
                            case "Drive":
                                theTruck.Drive(amout);
                                break;
                            case "Refuel":
                                theTruck.Refuel(amout);
                                break;
                        }
                        break;
                    case "Bus":
                        switch (driveOrRefuel)
                        {
                            case "Drive":
                                theBus.Drive(amout);
                                break;
                            case "DriveEmpty":
                                theBus.DriveEmpty(amout);
                                break;
                            case "Refuel":
                                theBus.Refuel(amout);
                                break;
                        }
                        break;
                }
            }
            Console.WriteLine($"Car: {theCar.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {theTruck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {theBus.FuelQuantity:f2}");
        }
    }
}
