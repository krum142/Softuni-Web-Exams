using System;
using System.Linq;
using SharedTrip.Models;
using SharedTrip.Services.interfaces;
using SharedTrip.ViewModels;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(CreateTripViewModel input)
        {
            var trip = new Trip()
            {
                Seats = input.Seats,
                DepartureTime = DateTime.Parse(input.DepartureTime),
                Description = input.Description,
                EndPoint = input.EndPoint,
                ImagePath = input.ImagePath,
                StartPoint = input.StartPoint,
            };

            db.Trip.Add(trip);
            db.SaveChanges();
        }

        public AllTripsViewModel GetAllTrips()
        {
            var trips = db.Trip
                .Select(t => new AllTripViewModel()
                {
                    Id = t.Id,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Seats = t.Seats // seats maybe have to be converted to string
                }).ToList();

            var viewModel = new AllTripsViewModel()
            {
                Trips = trips
            };

            return viewModel;
        }

        public TripDetailsViewModel GetById(string TripId)
        {
            var trip = db.Trip.Where(t => t.Id == TripId)
                .Select(t => new TripDetailsViewModel
                {
                    Id = t.Id,
                    Seats = t.Seats,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Description = t.Description,
                    EndPoint = t.EndPoint,
                    ImagePath = t.ImagePath,
                    StartPoint = t.StartPoint,
                }).FirstOrDefault();

            return trip;
        }

        public bool AddUserToTrip(string tripId, string userId)
        {
            var user = db.User.Where(u => u.Id == userId).FirstOrDefault();

            var trip = db.Trip.Where(t => t.Id == tripId).FirstOrDefault();

            if (trip.Seats <= 0 || IsUserAlreadyInTrip(tripId,userId))
            {
                return false;
            }

            trip.Seats--;

            var usertrip = new UserTrip()
            {
                User = user,
                Trip = trip
            };


            db.UserTrip.Add(usertrip);
            db.SaveChanges();

            return true;
        }

        private bool IsUserAlreadyInTrip(string tripId, string userId)
        {
            return db.UserTrip
                .Any(tu => tu.TripId == tripId && tu.UserId == userId);
        }

    }
}