using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting
{
    public class StartUp
    {
        static void Main()
        {
            var db = new FootballBettingContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
