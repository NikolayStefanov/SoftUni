using System;
using System.Collections.Generic;

namespace _8._Car_Salesman_exe
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var engines = new List<Engine>();
            CreateEngines(engines);
            var cars = new List<Car>();
            CreateCars(engines, cars);
            foreach (Car car in cars)
            {
                Console.WriteLine(car.Model + ":");
                foreach (Engine engine in engines)
                {
                    if (car.Engine == engine.Model)
                    {
                        Console.WriteLine($"  {engine.Model}:");
                        Console.WriteLine($"    Power: {engine.Power}");
                        if (engine.Displacement != 0)
                        {
                            Console.WriteLine($"    Displacement: {engine.Displacement}");
                        }
                        else
                        {
                            Console.WriteLine($"    Displacement: n/a");
                        }
                        if (engine.Efficiency != null)
                        {
                            Console.WriteLine($"    Efficiency: {engine.Efficiency}");
                        }
                        else
                        {
                            Console.WriteLine($"    Efficiency: n/a");

                        }
                        break;
                    }
                }
                if (car.Weight != 0)
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                if (car.Color != null)
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
                else
                {
                    Console.WriteLine($"  Color: n/a");
                }
            }
            
        }

        private static void CreateCars(List<Engine> engines, List<Car> cars)
        {
            var carLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < carLines; i++)
            {
                var currCarParams = Console.ReadLine().Split();
                var carModel = currCarParams[0];
                var carEngine = currCarParams[1];
                var carWeight = 0;
                var carColor = string.Empty;
                if (currCarParams.Length > 2)
                {
                    if (currCarParams.Length == 3)
                    {
                        var currWord = currCarParams[2];
                        var test = int.TryParse(currWord, out int result);
                        if (test)
                        {
                            carWeight = result;
                            var newestCar = new Car(carModel, carEngine, carWeight);
                            cars.Add(newestCar);
                        }
                        else
                        {
                            carColor = currWord;
                            var newestCar = new Car(carModel, carEngine, carColor);
                            cars.Add(newestCar);

                        }
                    }
                    else
                    {
                        carWeight = int.Parse(currCarParams[2]);
                        carColor = currCarParams[3];
                        var newestCar = new Car(carModel, carEngine, carColor, carWeight);
                        cars.Add(newestCar);
                    }
                }
                else
                {
                    var newestCar = new Car(carModel, carEngine);
                    cars.Add(newestCar);
                }
            }
        }

        private static void CreateEngines(List<Engine> engines)
        {
            int linesOfEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesOfEngines; i++)
            {
                var currEngineParameters = Console.ReadLine().Split();
                var modelOfEngine = currEngineParameters[0];
                var powerOfEngine = int.Parse(currEngineParameters[1]);
                var displacementOfEngine = 0;
                var efficiency = string.Empty;

                if (currEngineParameters.Length > 2)
                {
                    if (currEngineParameters.Length == 3)
                    {
                        var thirdParam = currEngineParameters[2];
                        var test = int.TryParse(thirdParam, out int result);
                        if (test)
                        {
                            displacementOfEngine = result;
                            var newestEngine = new Engine(modelOfEngine, powerOfEngine, displacementOfEngine);
                            engines.Add(newestEngine);
                        }
                        else
                        {
                            efficiency = thirdParam;
                            var newestEngine = new Engine(modelOfEngine, powerOfEngine, efficiency);
                            engines.Add(newestEngine);
                        }
                    }
                    else
                    {
                        displacementOfEngine = int.Parse(currEngineParameters[2]);
                        efficiency = currEngineParameters[3];
                        var newestEngine = new Engine(modelOfEngine, powerOfEngine, displacementOfEngine, efficiency);
                        engines.Add(newestEngine);
                    }
                }
                else
                {
                    var newestEngine = new Engine(modelOfEngine, powerOfEngine);
                    engines.Add(newestEngine);
                }
            }
        }
    }
}
