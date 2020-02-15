using System.ComponentModel.DataAnnotations;

namespace Andreys.App.ViewModels.Users
{
    public class RegisterInputModel
    {
        [MaxLength(10)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }


    }
}