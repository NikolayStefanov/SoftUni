using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> carTrack = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var fillUpCarTrack = Console.ReadLine().Split();
                var model = fillUpCarTrack[0];
                var fuelAmount = double.Parse(fillUpCarTrack[1]);
                var fuelConsumptionPerKm = double.Parse(fillUpCarTrack[2]);
                var sameModel = false;
                foreach (Car car in carTrack)
                {
                    if (car.Model == model)
                    {
                        sameModel = true;
                        break;
                    }
                }
                if (!sameModel)
                {
                    var currCar = new Car(model, fuelAmount, fuelConsumptionPerKm);
                    carTrack.Add(currCar);
                }
            }
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var commandInList = command.Split();
                var carModel = commandInList[1];
                var kilometers = double.Parse(commandInList[2]);
                var isEnough = true;

                foreach (Car car in carTrack)
                {
                    if (car.Model == carModel)
                    {
                        isEnough = car.Move(carModel, kilometers);
                        break;
                    }
                }
                if (!isEnough)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

            }
            foreach (Car car in carTrack)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
