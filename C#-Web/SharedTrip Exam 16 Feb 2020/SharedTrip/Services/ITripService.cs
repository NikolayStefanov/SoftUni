using SharedTrip.ViewModels.Trips;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        IEnumerable<TripViewModel> GetAll();
        void Add(string startPoint, string endPoint, string departureTime, int seats, string description, string imagePath, string currentUserId);
        TripViewModel GetTripById(string id);
        bool AddUserToTrip(string userId, string tripId);
    }
}
