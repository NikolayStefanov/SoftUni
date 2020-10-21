using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext db;

        public TripService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(string startPoint, string endPoint, string departureTime, int seats, string description, string imagePath, string currentUserId)
        {
            var newTrip = new Trip
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = DateTime.ParseExact(departureTime, "dd.MM.yyyy HH:mm", null),
                Seats = seats,
                Description = description,
                ImagePath = imagePath
            };
            var user = this.db.Users.Where(x => x.Id == currentUserId).FirstOrDefault();
            this.db.UserTrips.Add(new UserTrip { Trip = newTrip, User = user });
            this.db.Trips.Add(newTrip);
            this.db.SaveChanges();
        }

        public bool AddUserToTrip(string userId, string tripId)
        {
            var targetTrip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);

            try
            {
                if (targetTrip.Seats == 0)
                {
                    return false;
                }
                this.db.UserTrips.Add(new UserTrip { TripId = tripId, UserId = userId });
                targetTrip.Seats -= 1;
                this.db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(t => new TripViewModel
            {
                TripId = t.Id,
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Seats = t.Seats,
                Description = t.Description,
                ImagePath = t.ImagePath
            }).ToList();
            return trips;
        }

        public TripViewModel GetTripById(string id)
        {
            var targetTrip = this.db.Trips.Where(x => x.Id == id).Select(t => new TripViewModel
            {
                TripId = t.Id,
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                DepartureTime = t.DepartureTime.ToString("s"),
                Seats = t.Seats,
                Description = t.Description,
                ImagePath = t.ImagePath
            }).FirstOrDefault();
            return targetTrip;
        }
    }
}
