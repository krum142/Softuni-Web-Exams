using SharedTrip.Services.interfaces;
using SharedTrip.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.App.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CreateTripViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Redirect("/Trips/Add");
            }

            if (input.Description.Length > 80)
            {
                return this.Redirect("/Trips/Add");
            }

            tripsService.Create(input);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            var trips = tripsService.GetAllTrips();

            return this.View(trips);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            var trip = tripsService.GetById(tripId);

            return this.View(trip);
        }

        
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            //bool isUsereInTrip = tripsService.IsUserAlreadyInTrip(tripId, this.User);

            if (!tripsService.AddUserToTrip(tripId, this.User))
            {
                Redirect("/Trips/Details");
            }

            return Redirect("/Trips/All");
        }
    }
}