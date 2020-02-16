using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class Trip
    {

        public Trip()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserTrips = new HashSet<UserTrip>();
        }
        //•	Has an Id – a string, Primary Key

        public string Id { get; set; }
        //•	Has a StartPoint – a string (required)
        [Required]
        public string StartPoint { get; set; }
        //•	Has a EndPoint – a string (required)
        [Required]
        public string EndPoint { get; set; }
        //•	Has a DepartureTime – a datetime(required) (use format: "dd.MM.yyyy HH:mm")
        [Required]
        public DateTime DepartureTime { get; set; }
        //•	Has a Seats – an integer with min value 2 and max value 6 (required)
        public int Seats { get; set; }

        //•	Has a Description – a string with max length 80 (required)
        
        [Required]
        [MaxLength(80)]
        public string Description { get; set; }
        //•	Has a ImagePath – a string
        public string ImagePath { get; set; }
        //•	Has UserTrips collection – a UserTrip type
        public ICollection<UserTrip> UserTrips { get; set; }

    }
}
