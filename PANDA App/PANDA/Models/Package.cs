using System;
using System.ComponentModel.DataAnnotations;
using PANDA.Models.Enums;

namespace PANDA.Models
{
    public class Package
    {
        public Package()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        //•	Id - a GUID String, Primary Key

        public string Id { get; set; }
        //    •	Description - a string a string with min length 5 and max length 20(required)
        [Required]
        [MaxLength(20)]
        public string Description { get; set; }
        //    •	Weight - a floating - point number
        
        public double Weight { get; set; }
        //    •	Shipping Address -a string
        public string ShippingAddress { get; set; }

        //    •	Status - can be one of the following values("Pending", "Delivered")
        public Status Status { get; set; }
        //    •	Estimated Delivery Date - a DateTime object
        public DateTime EstimatedDeliveryDate { get; set; }
        //    •	RecipientId - GUID foreign key(required)
        [Required]
        public string RecipientId { get; set; }
        //    •	Recipient - a User object
        public User Recipient { get; set; }
    }
}
