using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PANDA.Models
{
    public class User
    {
        //•	Id - a GUID String, Primary Key
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Packages = new HashSet<Package>();
            this.Receipts = new HashSet<Receipt>();
        }
        public string Id { get; set; }

        //•	Username - a string with min length 5 and max length 20 (required)
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        //•	Email - a string with min length 5 and max length 20 (required)
        [Required]
        [MaxLength(20)]
        public string Email { get; set; }
        //•	Password - a string – hashed in the database(required)
        [Required]
        public string Password { get; set; }
        //    •	Packages – a Collection of type Packages
        public  ICollection<Package> Packages { get; set; }
        //•	Receipts – a Collection of type Receipts
        public ICollection<Receipt> Receipts { get; set; }

    }
}
