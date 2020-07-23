using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();
            ResetDatabase(dbContext);

            //EXERCISE 1 - Import Users
            var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            Console.WriteLine(ImportUsers(dbContext, usersXml));

            //EXERCISE 2 - Import Products
            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            Console.WriteLine(ImportProducts(dbContext, productsXml));

            //EXERCISE 3 - Import Categories
            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            Console.WriteLine(ImportCategories(dbContext, categoriesXml));

            //EXERCISE 4 - Import Categories and Products
            var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            Console.WriteLine(ImportCategoryProducts(dbContext, categoriesProductsXml));

            //ЕXERCISE 5 - Export Products In Range
            var resultProducts = GetProductsInRange(dbContext);
            Console.WriteLine(resultProducts);
            File.WriteAllText("../../../ExportedXMLs/products-in-range.xml", resultProducts);

            //EXERCISE 6 - Export Sold Products
            var resultUsersWithSoldProducts = GetSoldProducts(dbContext);
            Console.WriteLine(resultUsersWithSoldProducts);
            File.WriteAllText("../../../ExportedXMLs/users-sold-products.xml", resultUsersWithSoldProducts);

            //EXERCISE 7 -  Export Categories By Products Count
            var resultCategories = GetCategoriesByProductsCount(dbContext);
            Console.WriteLine(resultCategories);
            File.WriteAllText("../../../ExportedXMLs/categories-by-products.xml", resultCategories);

            //EXERCISE 8 - Users and Products
            var resultUsersAndSoldProduts = GetUsersWithProducts(dbContext);
            Console.WriteLine(resultUsersAndSoldProduts);
            File.WriteAllText("../../../ExportedXMLs/users-and-products.xml", resultUsersAndSoldProduts);

        }
        private static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            context.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        //EXERCISE 1 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootName = "Users"; 
            var usersResult = XmlConverter.Deserializer<ImportUserDto>(inputXml, rootName);

            var users = new List<User>();
            foreach (var user in usersResult)
            {
                var newUser = new User() { FirstName = user.FirstName, LastName = user.LastName, Age = user.Age };
                users.Add(newUser);
            }
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //EXERCISE 2 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootName = "Products";
            var productsResult = XmlConverter.Deserializer<ImportProductDto>(inputXml, rootName);

            var products = productsResult
                .Select(x => new Product { Name = x.Name, Price = x.Price, SellerId = x.SellerId, BuyerId = x.BuyerId })
                .ToArray();
            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //EXERCISE 3 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootName = "Categories";
            var categoriesResult = XmlConverter.Deserializer<ImportCategoryDto>(inputXml, rootName);
            var categories = categoriesResult
                .Where(x => x.Name != null)
                .Select(x => new Category { Name = x.Name })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //EXERCISE 4 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "CategoryProducts";

            var categoriesProductsResult = XmlConverter.Deserializer<ImportCategoryProductDto>(inputXml, rootElement);

            var categoriesCount = context.Categories.Count();
            var productsCount = context.Products.Count();

            var categoriesProducts = categoriesProductsResult
                .Where(x => x.CategoryId <= categoriesCount && x.ProductId <= productsCount)
                .Select(x => new CategoryProduct { CategoryId = x.CategoryId, ProductId = x.ProductId })
                .ToArray();
            context.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }

        //ЕXERCISE 5 - Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootName = "Products";

            var targetProducts = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ExportProductDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerFullName = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();
            var resultXml = XmlConverter.Serialize(targetProducts, rootName);

            return resultXml;
        }

        //EXERCISE 6 - Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var targetUsers = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new ExportUsersWithSoldProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(p => new ProductDto { Name = p.Name, Price = p.Price }).ToList()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();
            const string rootElement = "Users";
            var resultXml = XmlConverter.Serialize(targetUsers, rootElement);
            return resultXml;
        }

        //EXERCISE 7 -  Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";
            var targetCategories = context.Categories
                .Select(x => new ExportCategoriesDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();
            var resultXml = XmlConverter.Serialize(targetCategories, rootElement);
            return resultXml;
        }

        //EXERCISE 8 - Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var targetUsers = context.Users
                .ToArray()
                .Where(x=> x.ProductsSold.Any())
                .Select(x => new UserInfo
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProductCount
                    {
                        Count = x.ProductsSold.Count,
                        Products = x.ProductsSold.Select(p => new SoldProduct
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p=> p.Price)
                        .ToList()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .Take(10)
                .ToList();

            var finalObj = new ExportUserCountDto
            {
                Count = context.Users.Count(x=> x.ProductsSold.Any()),
                Users = targetUsers
            };

            const string rootName = "Users";
            var resultXml = XmlConverter.Serialize(finalObj, rootName);
            return resultXml;
        }
    }
}