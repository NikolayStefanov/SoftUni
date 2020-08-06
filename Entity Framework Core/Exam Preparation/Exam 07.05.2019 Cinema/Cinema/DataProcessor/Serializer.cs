namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var targetMovies = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(p=> p.Tickets.Any()))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("0.00"),
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("0.00"),
                    Customers = x.Projections.SelectMany(p => p.Tickets               
                    .Select(t => new
                    {
                        FirstName = t.Customer.FirstName,
                        LastName = t.Customer.LastName,
                        Balance = t.Customer.Balance.ToString("0.00")
                    }))
                    .OrderByDescending(t => t.Balance)
                    .ThenBy(t => t.FirstName)
                    .ThenBy(t => t.LastName)
                    .ToList()
                })
                .OrderByDescending(x => double.Parse(x.Rating))
                .ThenByDescending(x => double.Parse(x.TotalIncomes))
                .Take(10)
                .ToList();

            var targetMoviesJson = JsonConvert.SerializeObject(targetMovies, Formatting.Indented);
            return targetMoviesJson;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var targetCustomers = context.Customers
                .Where(x => x.Age >= age)
                .Select(x => new ExportTopCustomersDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(t => t.Price).ToString("0.00"),
                    SpentTime = TimeSpan.FromSeconds(x.Tickets.Sum(t => t.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")

                })
                .OrderByDescending(x=> decimal.Parse(x.SpentMoney))
                .Take(10)
                .ToList();

            var resultXml = XmlConverter.Serialize(targetCustomers, "Customers");
            return resultXml;
        }
    }
}