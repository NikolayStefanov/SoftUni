namespace PO1_HospitalDatabse
{
    using P01_HospitalDatabase.Data;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var hospitalContext = new HospitalContext();
            hospitalContext.Database.EnsureDeleted();
            hospitalContext.Database.EnsureCreated();
        }
    }
}
