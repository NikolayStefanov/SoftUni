using PetStore.Data;
using System;

namespace PetStore.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new PetStoreDbContext();
            dbContext.Database.EnsureDeleted();
        }
    }
}
