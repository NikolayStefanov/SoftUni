using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            ResetDatabase(db);

            // EXERCISE 1 - Import Users
            string usersJson = File.ReadAllText("../../../Datasets/users.json");
            Console.WriteLine(ImportUsers(db, usersJson));

            // EXERCISE 2 - Import Products
            var productsJson = File.ReadAllText("../../../Datasets/products.json");
            Console.WriteLine(ImportProducts(db, productsJson));

            // EXERCISE 3 - Import Categories
            var categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            Console.WriteLine(ImportCategories(db, categoriesJson));

            // EXERCISE 4 - Import Categories and Products
            var categoryProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(db, categoryProductsJson));

            //EXERCISE 5 - Export Products In Range
            Console.WriteLine(GetProductsInRange(db));

            //EXERCISE 6 - Export Successfully Sold Products
            Console.WriteLine(GetSoldProducts(db));

            //EXERCISE 7 - Export Categories by Products Count
            Console.WriteLine(GetCategoriesByProductsCount(db));

            //EXERCISE 8 - Export Users and Products
            Console.WriteLine(GetUsersWithProducts(db));
        }

        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        //EXERCISE 1 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            var deserializedUsersCount = users.Count;
            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {deserializedUsersCount}";
        }

        //EXERCISE 2 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            var deserializedProductsCount = products.Count;
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {deserializedProductsCount}";
        }

        //EXERCISE 3 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            }).Where(x => x.Name != null);
            var deserializedCategoriesCount = categories.Count();
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {deserializedCategoriesCount}";
        }

        //EXERCISE 4 -  Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            var deserializedCategoriyProductsCount = categoryProducts.Count;
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {deserializedCategoriyProductsCount}";
        }

        //EXERCISE 5 - Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var targetProducts = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .OrderBy(x => x.price)
                .ToList();
            var jsonString = JsonConvert.SerializeObject(targetProducts, Formatting.Indented);
            return jsonString;
        }

        //EXERCISE 6 - Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var targetProducts = context.Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Where(y => y.Buyer != null).Select(b => new
                    {
                        name = b.Name,
                        price = b.Price,
                        buyerFirstName = b.Buyer.FirstName,
                        buyerLastName = b.Buyer.LastName
                    })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();
            var jsonResult = JsonConvert.SerializeObject(targetProducts, Formatting.Indented);
            return jsonResult;
        }

        //EXERCISE 7 - Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var targetCategories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = x.CategoryProducts.Average(p => p.Product.Price).ToString("F"),
                    totalRevenue = x.CategoryProducts.Sum(t => t.Product.Price).ToString("F")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();
            var jsonResult = JsonConvert.SerializeObject(targetCategories, Formatting.Indented);
            return jsonResult;
        }

        //EXERCISE 8 - Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var targetUsers = context.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(x => x.ProductsSold.Count(p => p.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Where(b => b.Buyer != null).Count(),
                        products = x.ProductsSold.Where(b => b.Buyer != null).Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price
                        }).ToList()
                    }
                }).ToList();

            var usersResultObj = new
            {
                usersCount = targetUsers.Count,
                users = targetUsers,
            };

            return JsonConvert.SerializeObject(usersResultObj,
                                               new JsonSerializerSettings
                                               {
                                                   Formatting = Formatting.Indented
                                                                          ,
                                                   NullValueHandling = NullValueHandling.Ignore
                                               }
                                              );
        }
    }
}