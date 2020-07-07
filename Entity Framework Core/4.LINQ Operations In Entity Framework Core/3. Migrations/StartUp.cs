namespace P03_SalesDatabase
{
    using P03_SalesDatabase.Data;
    public class StartUp
    {
        static void Main()
        {
            var salesDbContext = new SalesContext();
            salesDbContext.Database.EnsureDeleted();
            salesDbContext.Database.EnsureCreated();
        }
    }
}
