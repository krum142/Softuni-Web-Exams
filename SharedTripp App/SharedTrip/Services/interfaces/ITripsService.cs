using SharedTrip.ViewModels;

namespace SharedTrip.Services.interfaces
{
    public interface ITripsService
    {
        void Create(CreateTripViewModel input);

        TripDetailsViewModel GetById(string TripId);

        AllTripsViewModel GetAllTrips();

        bool AddUserToTrip(string tripId, string userId);
        //bool IsUserAlreadyInTrip(string tripId, string userId);
    }
}