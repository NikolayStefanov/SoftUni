namespace Entity_Relations_with_Code_First
{
    using P01_StudentSystem.Data;

    public class StartUp
    {
        static void Main()
        {
            var dbContext = new StudentSystemContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            
        }
    }
}
