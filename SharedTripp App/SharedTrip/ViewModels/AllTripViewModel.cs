namespace SharedTrip.ViewModels
{
    public class AllTripViewModel
    {
        public string Id { get; set; } // bug maybe be careful .. all good so far :D

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public string DepartureTime { get; set; }

        public int Seats { get; set; }
    }
}