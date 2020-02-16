using System.Collections.Generic;

namespace SharedTrip.ViewModels
{
    public class AllTripsViewModel
    {
        public ICollection<AllTripViewModel> Trips { get; set; }
    }
}