using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();
            ResetDatabase(dbContext);

            // EXERCISE 9 - Import Suppliers
            var supplierJson = File.ReadAllText("../../../Datasets/suppliers.json");
            Console.WriteLine(ImportSuppliers(dbContext, supplierJson));

            // EXERCISE 10 - Import Parts
            var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(dbContext, partsJson));

            // EXERCISE 11 - Import Cars
            var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            Console.WriteLine(ImportCars(dbContext, carsJson));

            // EXERCISE 12 - Import Customers
            var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            Console.WriteLine(ImportCustomers(dbContext, customersJson));

            // EXERCISE 13 - Import Sales
            var salesJson = File.ReadAllText("../../../Datasets/sales.json");
            Console.WriteLine(ImportSales(dbContext, salesJson));

            //EXERCISE 14 - Export Ordered Customers
            Console.WriteLine(GetOrderedCustomers(dbContext));

            //EXERCISE 15 - Export Cars from Make Toyota
            Console.WriteLine(GetCarsFromMakeToyota(dbContext));

            //EXERCISE 16 -  Export Local Suppliers
            Console.WriteLine(GetLocalSuppliers(dbContext));

            //EXERCISE 17 - Export Cars with Their List of Parts
            Console.WriteLine(GetCarsWithTheirListOfParts(dbContext));

            //EXERCISE 18 - Export Total Sales by Customer
            Console.WriteLine(GetTotalSalesByCustomer(dbContext));

            //EXERCISE 19 - Export Sales With Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(dbContext));

        }
        private static void ResetDatabase(CarDealerContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            Console.WriteLine("CarDealer database was successfully deleted!");
            dbContext.Database.EnsureCreated();
            Console.WriteLine("CarDealer database was successfully created!");
        }

        //EXERCISE 9 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //EXERCISE 10 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierCount = context.Suppliers.Count();
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson).Where(x=>x.SupplierId <= supplierCount);
            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count()}.";
        }

        //EXERCISE 11 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);
            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                
                var newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,

                };
                cars.Add(newCar);

                foreach (var carPartId in carDto.PartsId.Distinct())
                {
                    var newCarPart = new PartCar()
                    {
                        PartId = carPartId,
                        Car = newCar
                    };
                    carParts.Add(newCarPart);
                }
                
            }
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported { cars.Count()}.";
        }

        //EXERCISE 12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported { customers.Count()}.";
        }

        //EXERCISE 13 -  Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
  
            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported { sales.Count()}.";
        }

        //EXERCISE 14 - Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var targetCustomers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToList();
            var result = JsonConvert.SerializeObject(targetCustomers, Formatting.Indented);
            return result;
        }

        //EXERCISE 15 - Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var targetCars = context.Cars
                .Where(x => x.Make.ToLower() == "toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                }).ToList();
            var toyotaCarsJson = JsonConvert.SerializeObject(targetCars, Formatting.Indented);
            return toyotaCarsJson;
        }

        //EXERCISE 16 -  Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                }).ToList();

            var suppliersJsonResult = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return suppliersJsonResult;
        }

        //EXERCISE 17 - Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var targetCars = context.Cars
                .Select(c => new
                {
                    car = new { c.Make, c.Model, c.TravelledDistance },
                    parts = c.PartCars.Select(x => new { Name = x.Part.Name, Price = x.Part.Price.ToString("F") }).ToList()
                }).ToList();
            var resultJson = JsonConvert.SerializeObject(targetCars, Formatting.Indented);
            return resultJson;
        }

        //EXERCISE 18 - Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var targetCars = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new
                {
                    fullName = $"{x.Name}",
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(c => c.Car.PartCars.Sum(y => y.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();
            var resultJson = JsonConvert.SerializeObject(targetCars, Formatting.Indented);
            return resultJson;
        }

        //EXERCISE 19 - Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var targetCars = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new { x.Car.Make, x.Car.Model, x.Car.TravelledDistance },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(s=> s.Part.Price).ToString("F"),
                    priceWithDiscount = (x.Car.PartCars.Sum(s=> s.Part.Price) * (1M - x.Discount / 100M)).ToString("F")
                }).ToList();

            var resultJson = JsonConvert.SerializeObject(targetCars, Formatting.Indented);
            return resultJson;
        }
    }
}