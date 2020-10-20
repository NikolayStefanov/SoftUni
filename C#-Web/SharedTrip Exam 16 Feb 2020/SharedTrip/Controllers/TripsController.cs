using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(ITripService tripService)
        {
            this.tripService = tripService;
        }
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            var trips = this.tripService.GetAll();
            return this.View(trips);
        }
        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Add(TripViewModel tripInputModel)
        {
            if (tripInputModel.Seats < 2 || tripInputModel.Seats > 6)
            {
                return this.View("/Trips/Add");
            }
            var currentUserId = this.GetUserId();
            this.tripService.Add(tripInputModel.StartPoint, tripInputModel.EndPoint, tripInputModel.DepartureTime, tripInputModel.Seats,tripInputModel.Description, tripInputModel.ImagePath, currentUserId);
            return this.Redirect("/Trips/All");
        }
        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            var viewModel = this.tripService.GetTripById(tripId);
            return this.View(viewModel);
        }
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            var currentUserId = this.GetUserId();
            var resultOfAdd = this.tripService.AddUserToTrip(currentUserId, tripId);
            if (resultOfAdd)
            {
                return this.All();
            }
            else
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }
            
        }
    }
}
