using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserTrips = new HashSet<UserTrip>();
        }

        public string Id { get; set; }

        //•	Username - a string with min length 5 and max length 20 (required)
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        //•	Email - a string with min length 5 and max length 20 (required)
        [Required]
        public string Email { get; set; }
        //•	Password - a string – hashed in the database(required)
        [Required]
        public string Password { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
