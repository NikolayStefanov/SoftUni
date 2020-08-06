namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movieDtos = JsonConvert.DeserializeObject<MovieDto[]>(jsonString);
            var validMoviesToAdd = new List<Movie>();
            var outputResult = new StringBuilder();

            foreach (var movieDto in movieDtos)
            {
                Genre genre;
                var isGenreValid = Enum.TryParse<Genre>(movieDto.Genre, true, out genre);
                var isTitleExists = context.Movies.Any(x => x.Title == movieDto.Title);
                if (!IsValid(movieDto) || !isGenreValid || isTitleExists)
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }

                validMoviesToAdd.Add(new Movie
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Duration = TimeSpan.ParseExact(movieDto.Duration, @"h\:mm\:ss", CultureInfo.InvariantCulture),
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                });

                outputResult.AppendLine(string.Format(SuccessfulImportMovie, movieDto.Title, movieDto.Genre, movieDto.Rating.ToString("0.00")));
            }
            context.Movies.AddRange(validMoviesToAdd);
            context.SaveChanges();
            return outputResult.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var outputResult = new StringBuilder();
            var hallSeatsDtos = JsonConvert.DeserializeObject<HallSeatsDto[]>(jsonString);

            var validHallsToAdd = new List<Hall>();

            foreach (var hallDto in hallSeatsDtos)
            {
                if (!IsValid(hallDto))
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }

                var newHall = new Hall
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    newHall.Seats.Add(new Seat { Hall = newHall });
                }

                validHallsToAdd.Add(newHall);

                if (newHall.Is4Dx && newHall.Is3D)
                {
                    outputResult.AppendLine(string.Format(SuccessfulImportHallSeat, newHall.Name, "4Dx/3D", hallDto.Seats));
                    continue;
                }
                else if (newHall.Is4Dx)
                {
                    outputResult.AppendLine(string.Format(SuccessfulImportHallSeat, newHall.Name, "4Dx", hallDto.Seats));
                    continue;
                }
                else if (newHall.Is3D)
                {
                    outputResult.AppendLine(string.Format(SuccessfulImportHallSeat, newHall.Name, "3D", hallDto.Seats));
                    continue;
                }
                else
                {
                    outputResult.AppendLine(string.Format(SuccessfulImportHallSeat, newHall.Name, "Normal", hallDto.Seats));
                }
            }

            context.Halls.AddRange(validHallsToAdd);
            context.SaveChanges();

            return outputResult.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var outputResult = new StringBuilder();
            var projectionsDtos = XmlConverter.Deserializer<ProjectionDto>(xmlString, "Projections");

            var validProjectionsToAdd = new List<Projection>();

            foreach (var projectionDto in projectionsDtos)
            {
                var isMovieValid = context.Movies.All(x => x.Id != projectionDto.MovieId);
                var isHallValid = context.Halls.All(x => x.Id != projectionDto.HallId);
                if (!IsValid(projectionDto) || isMovieValid || isHallValid)
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }

                var newMovie = new Projection
                {
                    MovieId = projectionDto.MovieId,
                    HallId = projectionDto.HallId,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };
                validProjectionsToAdd.Add(newMovie);
                var targetMovieTitle = context.Movies.Where(x => x.Id == newMovie.MovieId).Select(x => x.Title).FirstOrDefault();
                outputResult.AppendLine(string.Format
                    (
                    SuccessfulImportProjection,
                    targetMovieTitle,
                    newMovie.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture))
                    );
            }
            context.Projections.AddRange(validProjectionsToAdd);
            context.SaveChanges();

            return outputResult.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var outputResult = new StringBuilder();
            var customerTicketsDtos = XmlConverter.Deserializer<CustomerTicketsDto>(xmlString, "Customers");

            var validCustomersToAdd = new List<Customer>();
            foreach (var customerTicketsDto in customerTicketsDtos)
            {
                if (!IsValid(customerTicketsDto))
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }
                var newCustomer = new Customer
                {
                    FirstName = customerTicketsDto.FirstName,
                    LastName = customerTicketsDto.LastName,
                    Age = customerTicketsDto.Age,
                    Balance = customerTicketsDto.Balance
                };
                foreach (var ticket in customerTicketsDto.Tickets)
                {
                    newCustomer.Tickets.Add(new Ticket
                    {
                        ProjectionId = ticket.ProjectionId,
                        Price = ticket.Price
                    });
                }
                validCustomersToAdd.Add(newCustomer);
                outputResult.AppendLine(string.Format(SuccessfulImportCustomerTicket, newCustomer.FirstName, newCustomer.LastName, newCustomer.Tickets.Count));
            }
            context.Customers.AddRange(validCustomersToAdd);
            context.SaveChanges();

            return outputResult.ToString().TrimEnd();
        }
        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}