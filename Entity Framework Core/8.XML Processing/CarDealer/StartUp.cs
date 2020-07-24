using CarDealer.Data;
using CarDealer.DataTransferObjects.ExportDtos;
using CarDealer.DataTransferObjects.ImportDtos;
using CarDealer.Models;
using CarDealer.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();
            ResetDatabase(dbContext);

            //EXERCISE 9 - Import Suppliers
            var importSuppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            var resultOfSuppliersImport = ImportSuppliers(dbContext, importSuppliersXml);
            Console.WriteLine(resultOfSuppliersImport);

            //EXERCISE 10 - Import Parts
            var importPartsXml = File.ReadAllText("../../../Datasets/parts.xml");
            var resultOfPartsImport = ImportParts(dbContext, importPartsXml);
            Console.WriteLine(resultOfPartsImport);

            //EXERCISE 11 - Import Cars
            var importCarsXml = File.ReadAllText("../../../Datasets/cars.xml");
            var resultOfCarsImport = ImportCars(dbContext, importCarsXml);
            Console.WriteLine(resultOfCarsImport);

            //EXERCISE 12 - Import Customers
            var importCustomersXml = File.ReadAllText("../../../Datasets/customers.xml");
            var resultOfCustomersImport = ImportCustomers(dbContext, importCustomersXml);
            Console.WriteLine(resultOfCustomersImport);

            //EXERCISE 13 - Import Sales
            var importSalesXml = File.ReadAllText("../../../Datasets/sales.xml");
            var resultOfSalesImport = ImportSales(dbContext, importSalesXml);
            Console.WriteLine(resultOfSalesImport);

            //EXERCISE 14 - Export Cars With Distance
            var carsWithDistanceXml = GetCarsWithDistance(dbContext);
            Console.WriteLine(carsWithDistanceXml);
            File.WriteAllText("../../../ExportedXMLs/carsWithDistance.xml", carsWithDistanceXml);

            //EXERCISE 15 - Export Cars From Make BMW
            var bmwCarsXml = GetCarsFromMakeBmw(dbContext);
            Console.WriteLine(bmwCarsXml);
            File.WriteAllText("../../../ExportedXMLs/allBMWs.xml", bmwCarsXml);

            //EXERCISE 16 - Export Local Suppliers
            var localSuppliers = GetLocalSuppliers(dbContext);
            Console.WriteLine(localSuppliers);
            File.WriteAllText("../../../ExportedXMLs/localSuppliers.xml", localSuppliers);

            //EXERCISE 17 - Export Cars With Their List Of Parts
            var carsWithTheirParts = GetCarsWithTheirListOfParts(dbContext);
            Console.WriteLine(carsWithTheirParts);
            File.WriteAllText("../../../ExportedXMLs/carsWithTheirParts.xml", carsWithTheirParts);

            //EXERCISE 18 - Export Total Sales By Customer
            var customersWithSalesAndSpents = GetTotalSalesByCustomer(dbContext);
            Console.WriteLine(customersWithSalesAndSpents);
            File.WriteAllText("../../../ExportedXMLs/customersWithSalesAndSpents.xml", customersWithSalesAndSpents);

            //EXERCISE 19 - Export Sales With Applied Discount
            var salesWithDiscount = GetSalesWithAppliedDiscount(dbContext);
            Console.WriteLine(salesWithDiscount);
            File.WriteAllText("../../../ExportedXMLs/salesWithDiscount.xml", salesWithDiscount);
        }

        private static void ResetDatabase(CarDealerContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            dbContext.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        //EXERCISE 9 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string rootName = "Suppliers";
            var suppliersDtos = XmlConverter.Deserializer<SupplierDTO>(inputXml, rootName);
            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDtos)
            {
                var newSupplier = new Supplier { Name = supplierDto.Name, IsImporter = supplierDto.IsImporter };
                suppliers.Add(newSupplier);
            }

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";

        }

        //EXERCISE 10 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string rootName = "Parts";
            var resultDtoObjects = XmlConverter.Deserializer<PartDTO>(inputXml, rootName);

            var suppliersCount = context.Suppliers.Count();
            var parts = resultDtoObjects
                .Where(x => x.SupplierId > 0 && x.SupplierId <= suppliersCount)
                .Select(x=> new Part { Name = x.Name, Price = x.Price, Quantity = x.Quantity, SupplierId = x.SupplierId})
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //EXERCISE 11 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string rootName = "Cars";

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            var partsCount = context.Parts.Count();
            var resultCarDtos = XmlConverter.Deserializer<CarDTO>(inputXml, rootName);

            foreach (var car in resultCarDtos)
            {
                var newCar = new Car { Make = car.Make, Model = car.Model, TravelledDistance = car.TraveledDistance };

                cars.Add(newCar);
                foreach (var partId in car.CarParts.Select(x=> new { partId = x.PartId}).Distinct())
                {
                    var newCarPart = new PartCar
                    {
                        PartId = partId.partId,
                        Car = newCar
                    };
                    carParts.Add(newCarPart);
                }
            }
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //EXERCISE 12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string rootName = "Customers";
            var resultCustomerDtos = XmlConverter.Deserializer<CustomerDTO>(inputXml, rootName);

            var resultCustomers = resultCustomerDtos
                .Select(x => new Customer { Name = x.Name, BirthDate = x.BirthDate, IsYoungDriver = x.IsYoungDriver })
                .ToArray();
            context.AddRange(resultCustomers);
            context.SaveChanges();
            return $"Successfully imported {resultCustomers.Count()}";
        }

        //EXERCISE 13 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string rootName = "Sales";
            var resultSalesDtos = XmlConverter.Deserializer<SalesDTO>(inputXml, rootName);

            var salesToImport = resultSalesDtos
                .Where(x => context.Cars.Any(c => c.Id == x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToArray();

            context.Sales.AddRange(salesToImport);
            context.SaveChanges();

            return $"Successfully imported {salesToImport.Length}";
        }

        //EXERCISE 14 - Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const string rootName = "cars";
            var targetCars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Select(x => new ExportCarsDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .Take(10)
                .ToList();

            var carsXmlResult = XmlConverter.Serialize(targetCars, rootName);
            return carsXmlResult;
        }

        //EXERCISE 15 - Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var targetCars = context.Cars
                .Where(x => x.Make.ToLower() == "bmw")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new ExportBMWsDTO
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                }).ToList();

            var resultXml = XmlConverter.Serialize(targetCars, "cars");
            return resultXml;
        }

        //EXERCISE 16 - Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var targetSuppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new ExportLocalSuppliersDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                }).ToArray();

            var resultXml = XmlConverter.Serialize(targetSuppliers, "suppliers");
            return resultXml;

        }

        //EXERCISE 17 - Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var targetCars = context.Cars
                .Select(x => new ExportCarsWithPartsDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars
                    .Select(pc => new CarPart { Name = pc.Part.Name, Price = pc.Part.Price })
                    .OrderByDescending(pc => pc.Price)
                    .ToList()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToList();

            var resultXml = XmlConverter.Serialize(targetCars, "cars");
            return resultXml;
        }

        //EXERCISE 18 -Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {

            var targetCustomers = context.Sales
                .Where(x => x.Customer.Sales.Any())
                .Select(x => new ExportCustomersWithBoughtCarsDTO
                {
                    FullName = x.Customer.Name,
                    BoughtCarsCount = x.Customer.Sales.Count,
                    SpentMoney = x.Car.PartCars.Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();
            var resultXml = XmlConverter.Serialize(targetCustomers, "customers");

            return resultXml;
        }

        //EXERCISE 19 - Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var targetSales = context.Sales
                .Select(x => new ExportSalesWithAppliedDiscountDTO
                {
                    Car = new CarInfo { Make = x.Car.Make, Model = x.Car.Model, TravelledDistance = x.Car.TravelledDistance },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount =  x.Car.PartCars.Sum(pc => pc.Part.Price) - x.Car.PartCars.Sum(pc => pc.Part.Price) * x.Discount / 100.0M
                }).ToArray();

            var resultXml = XmlConverter.Serialize(targetSales, "sales");
            return resultXml;
        }
    }
}