using SharedTrip.Services;
using SharedTrip.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService usersService;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            var userId = usersService.GetUserId(username, password);

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                this.Redirect("/");
            }

            this.SignOut();

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterViewModel input)
        {

            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(input.Username))
            {
                return Redirect("/Users/Register");
            }
            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return Redirect("/Users/Register");
            }

            if (string.IsNullOrWhiteSpace(input.Password))
            {
                return Redirect("/Users/Register");

            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return Redirect("/Users/Register");

            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return Redirect("/Users/Register");
            }

            usersService.CreateUser(input);

            return Redirect("/Users/Login");
        }
    }
}