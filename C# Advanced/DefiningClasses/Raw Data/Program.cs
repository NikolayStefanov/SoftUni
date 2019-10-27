using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Raw_Data_exe
{
    public class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < lines; i++)
            {
                var command = Console.ReadLine().Split();
                var model = command[0];
                var engineSpeed = int.Parse(command[1]);
                var enginePower = int.Parse(command[2]);
                var cargoWeight = int.Parse(command[3]);
                var cargoType = command[4];
                var tirePressure = new double[4];
                tirePressure[0] = double.Parse(command[5]);
                tirePressure[1] = double.Parse(command[7]);
                tirePressure[2] = double.Parse(command[9]);
                tirePressure[3] = double.Parse(command[11]);
                var tireAge = new int[4];
                tireAge[0] = int.Parse(command[6]);
                tireAge[1] = int.Parse(command[8]);
                tireAge[2] = int.Parse(command[10]);
                tireAge[3] = int.Parse(command[12]);
                var currCar = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tirePressure, tireAge);
                cars.Add(currCar);
            }
            var condition = Console.ReadLine();
            if (condition == "fragile")
            {
                foreach (Car car in cars.Where(x=> x.Cargo.CargoType == "fragile"))
                {
                    foreach (var tire in car.Tires.Pressure.Where(x=> x < 1.0))
                    {
                        Console.WriteLine(car.Model);
                        break;
                    }
                }
            }
            else if (condition == "flamable")
            {
                foreach (Car car in cars.Where(x=> x.Engine.EnginePower > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }

        }
    }
}
